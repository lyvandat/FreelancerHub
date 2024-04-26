using DeToiServer.Dtos.AdminDto;

namespace DeToiServer.Services.AdminService
{
    public interface IAdminService
    {
        Task<GetOverviewDataAdminDto> GetAllOverviewDataAdmin(ServiceOverviewQueryDto queryStat);
    }
}
