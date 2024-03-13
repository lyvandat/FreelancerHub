using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Models;
using DeToiServerCore.Common.Helper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace DeToiServer.RealTime
{
    public class ChatHub : Hub<IChatClient>
    {
        private readonly DataContext _context;

        public ChatHub(DataContext context)
        {
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
                            var freelanceAddress = acc.Address.First();

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

        public async Task SendMessageToCustomer(GetFreelanceMatchingDto matchingFreelancer)
        {
            var user = await _context.Users
                .AsNoTracking()
                .Include(u => u.Connections)
                .FirstOrDefaultAsync(user => user.Phone.Equals(matchingFreelancer.Account.Phone));

            if (user?.Connections != null)
            {
                foreach (var connection in user.Connections)
                {
                    await Clients.Client(connection.ConnectionId).ReceiveFreelancerResponse(matchingFreelancer);
                }
            }
        }

        public override async Task OnConnectedAsync()
        {
            var phone = Context.GetHttpContext()?.Request.Query["phone"].ToString();

            if (!string.IsNullOrEmpty(phone))
            {
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