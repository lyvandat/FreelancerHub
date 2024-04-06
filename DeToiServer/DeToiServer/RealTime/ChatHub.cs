using AutoMapper;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.RealTimeDtos;
using DeToiServer.Models;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.OrderManagementService;
using DeToiServerCore.Common.Helper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace DeToiServer.RealTime
{
    public class ChatHub : Hub<IChatClient>
    {
        private readonly IFreelanceAccountService _freelancerService;
        private readonly ICustomerAccountService _customerService;
        private readonly IOrderManagementService _orderService;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ChatHub(DataContext context, IFreelanceAccountService freelancerService, ICustomerAccountService customerService, IOrderManagementService orderService, IMapper mapper)
        {
            _freelancerService = freelancerService;
            _customerService = customerService;
            _orderService = orderService;
            _mapper = mapper;
            _context = context;
        }

        public async Task SendMessageToFreelancer(PostOrderDto order)
        {
            // Get freelance accounts that are in the acceptable zone.
            var freelanceAccounts = await _context.Freelancers
                .AsNoTracking()
                .Include(fl => fl.Account)
                .Include(fl => fl.Address)
                .ToListAsync();

            freelanceAccounts = freelanceAccounts
                    .Where(acc => {
                        if (acc.Address != null && acc.Address.Count > 0)
                        {
                            var freelanceAddress = acc.Address.FirstOrDefault();

                            if (freelanceAddress == null) return false;

                            return Helper.IsInAcceptableZone(
                                new Coordination()
                                {
                                    Lat = order.Address.Lat,
                                    Lon = order.Address.Lon
                                },
                                new Coordination()
                                {
                                    Lat = freelanceAddress.Lat,
                                    Lon = freelanceAddress.Lon
                                }); 
                        }
                        return false;
                    }).ToList();

            // Online users that are connecting to SignalR
            var users = await _context.Users
                .AsNoTracking()
                .Include(u => u.Connections)
                .ToListAsync();

            // Send a message to the online freelancers
            foreach (var freelanceAcc in freelanceAccounts)
            {
                foreach (var user in users)
                {
                    if (user.Phone.Equals(freelanceAcc.Account.Phone))
                    {
                        if (user.Connections != null)
                        {
                            foreach (var connection in user.Connections)
                            {
                                await Clients.Client(connection.ConnectionId).ReceiveCustomerOrder(order);
                            }
                        }
                    }
                }
            }
        }

        public async Task SendReceiveOrderMessageToFreelancer(string freelancerPhone, GetOrderDto getOrderDto)
        {
            // Online users that are connecting to SignalR
            var users = await _context.Users
                .AsNoTracking()
                .Include(u => u.Connections)
                .ToListAsync();

            // Send a message to the online freelancers
            foreach (var user in users)
            {
                if (user.Phone.Equals(freelancerPhone))
                {
                    if (user.Connections != null)
                    {
                        foreach (var connection in user.Connections)
                        {
                            await Clients.Client(connection.ConnectionId).ReceiveConfirmCustomerOrder(getOrderDto);
                        }
                    }
                }
            }
        }

        public async Task SendMessageToCustomer(GetFreelancerAndPreviewPriceDto matchingFreelancer)
        {
            var freelancer = await _freelancerService.GetDetailWithStatistic(matchingFreelancer.FreelancerId);
            var order = await _orderService.GetById(matchingFreelancer.OrderId);
            
            if (order == null) return;

            var customer = await _customerService.GetByIdWithAccount(order.CustomerId);

            var user = await _context.Users
                .AsNoTracking()
                .Where(u => u.Phone.Equals(customer.Account.Phone))
                .Include(u => u.Connections)
                .FirstOrDefaultAsync();

            var biddingOrder = _mapper.Map<BiddingOrder>(matchingFreelancer);
            var existingBiddingOrder = await _context.BiddingOrders
                .Where(bo => bo.OrderId == biddingOrder.OrderId && bo.FreelancerId == biddingOrder.FreelancerId)
                .FirstOrDefaultAsync();

            if (existingBiddingOrder != null)
            {
                // Add Notification here for fe to catch
                return;
            }

            if (user?.Connections != null)
            {
                freelancer.PreviewPrice = matchingFreelancer.PreviewPrice;

                foreach (var connection in user.Connections)
                {
                    await Clients.Client(connection.ConnectionId).ReceiveFreelancerResponse(freelancer);
                }
            }

            // Save bidding orders
            try
            {
                _context.BiddingOrders.Add(biddingOrder);
                await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                Console.WriteLine("Cannot save bidding order");
            }
        }

        public async Task SendOrderStatusToCustomer(UpdateOrderStatusRealTimeDto orderStatus)
        {
            var user = await _context.Users
                .AsNoTracking()
                .Include(u => u.Connections)
                .FirstOrDefaultAsync(user => user.Phone.Equals(orderStatus.CustomerPhone));

            if (user?.Connections != null)
            {
                foreach (var connection in user.Connections)
                {
                    await Clients.Client(connection.ConnectionId).ReceiveFreelancerStatusResponse(new UpdateOnMovingOrderStatusDto()
                    {
                        ServiceStatusId = orderStatus.ServiceStatusId,
                        Address = orderStatus.Address
                    });
                }
            }
        }

        public override async Task OnConnectedAsync()
        {
            var phone = Context.GetHttpContext()?.Request.Query["phone"].ToString();

            if (!string.IsNullOrEmpty(phone))
            {
                phone = $"+{phone.Trim()}";
                var user = _context.Users
                .Include(u => u.Connections)
                .SingleOrDefault(u => u.Phone == phone);

                if (user == null)
                {
                    user = new User
                    {
                        Phone = phone,
                        Connections = new List<Connection>()
                    };
                    _context.Users.Add(user);
                }

                user.Connections!.Add(new Connection
                {
                    ConnectionId = Context.ConnectionId,
                    UserAgent = Context.GetHttpContext()?.Request.Headers["User-Agent"],
                    Connected = true
                });

                await _context.SaveChangesAsync();
            }
            else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "guests");
            }

            await base.OnConnectedAsync();
        }

        // TODO: Do we actually remove as much info as possible
        public override async Task OnDisconnectedAsync(Exception? ex)
        {
            var phone = Context.GetHttpContext()?.Request.Query["phone"].ToString();
            var connection = _context.Connections.Find(Context.ConnectionId);

            // Remove officers' connection from the db
            if (connection != null)
            {
                _context.Connections.Remove(connection);

                // remove the user(phone) that doesn't have any connection.
                var connectionCount = _context.Connections.Where(con => con.UserPhone == connection.UserPhone).Count();

                if (connectionCount == 1)
                {
                    var userWithLastConnection = _context.Users.Find(connection.UserPhone);

                    // Check if the entity exists
                    if (userWithLastConnection != null)
                    {
                        // Remove the entity from the context
                        _context.Users.Remove(userWithLastConnection);
                    }
                }

            }

            // Remove guests from the guests group
            if (string.IsNullOrEmpty(phone))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, "guests");
            }

            await _context.SaveChangesAsync();
            await base.OnDisconnectedAsync(ex);
        }
    }
}