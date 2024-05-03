using DeToiServer.Dtos.ChattingDtos;
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
        Task ReceiveRealtimeMessageFromAccount(MessageDto message);
        Task ErrorOccurred(NotificationDto message);
    }
}
