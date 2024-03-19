using DeToiServer.Dtos.FreelanceDtos;

namespace DeToiServer.Services.MessageQueueService
{
    public interface IMessageQueueService
    {
        void SendFreelancerDetailToCustomer(Guid orderId, GetFreelanceMatchingDto freelanceDto);
    }
}
