
using DeToiServer.Dtos.ServiceStatusDtos;

namespace DeToiServer.Services.ServiceStatusService
{
    public interface IServiceStatusService
    {
        Task<IEnumerable<GetServiceStatusDto>> GetAll();
    }
}
