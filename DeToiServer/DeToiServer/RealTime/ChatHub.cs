using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Models;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.Models;
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

        public async Task SendMessageToFreelancer(string region, PostOrderDto order)
        {
            // Get freelance accounts that are in the acceptable zone.
            var freelanceAccounts = await _context.Freelancers
                .AsNoTracking()
                .Include(fl => fl.Account)
                .ToListAsync();

            freelanceAccounts = freelanceAccounts
                    .Where(acc => Helper.IsInAcceptableZone(region, region))
                    .ToList();

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
                                await Clients.Client(connection.ConnectionId)
                                    .SendOrder(order);
                            }
                        }
                    }
                }
            }
        }

        public async Task SendMessageToCustomer(GetFreelanceAccountDto freelance, double price)
        {
            var user = await _context.Users
                .AsNoTracking()
                .Include(u => u.Connections)
                .FirstOrDefaultAsync(user => user.Phone.Equals(freelance.Account.Phone));

            if (user?.Connections != null)
            {
                foreach (var connection in user.Connections)
                {
                    await Clients.Client(connection.ConnectionId).ReceiveFreelanceResponse(freelance, price);
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