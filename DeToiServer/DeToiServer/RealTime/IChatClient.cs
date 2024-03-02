using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.OrderDtos;

namespace DeToiServer.RealTime
{
    public interface IChatClient
    {
        Task ReceiveCustomerOrder(PostOrderDto postOrder);
        Task ReceiveFreelancerResponse(GetFreelanceMatchingDto matchingFreelancer);
    }
}
