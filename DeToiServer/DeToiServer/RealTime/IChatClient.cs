using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.OrderDtos;

namespace DeToiServer.RealTime
{
    public interface IChatClient
    {
        Task SendOrder(PostOrderDto postOrder);
        Task ReceiveFreelanceResponse(GetFreelanceAccountDto freelance, double price);
    }
}
