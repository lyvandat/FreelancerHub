using DeToiServer.Dtos.AdminDto;

namespace DeToiServer.Services.AdminService
{
    public interface IAdminService
    {
        Task<GetOverviewDataAdminDto> GetAllOverviewDataAdmin(int? month = null, int? year = null);
    }
}
