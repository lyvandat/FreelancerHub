using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.NotificationDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.RealTimeDtos;

namespace DeToiServer.RealTime
{
    public interface IChatClient
    {
        Task ReceiveCustomerOrder(PostOrderDto postOrder);
        Task ReceiveFreelancerResponse(GetFreelanceMatchingDto matchingFreelancer);
        Task ReceiveFreelancerStatusResponse(UpdateOnMovingOrderStatusDto onMovingStatusDto);
        Task ReceiveFreelancerPositionResponse(UpdateMovingStatusDto onMovingStatusDto);
        Task ReceiveConfirmCustomerOrder(GetOrderDto getOrderDto);
        Task ReceiveFreelancerFeasibleOrder(GetOrderDto getOrderDto);
        Task ErrorOccurred(NotificationDto message);
    }
}
