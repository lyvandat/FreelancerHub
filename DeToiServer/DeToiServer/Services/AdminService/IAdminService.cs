using DeToiServer.Dtos.AdminDto;
using DeToiServerCore.Models.Accounts;

namespace DeToiServer.Services.AdminService
{
    public interface IAdminService
    {
        Task<GetOverviewDataAdminDto> GetAllOverviewDataAdmin(ServiceOverviewQueryDto queryStat);
        Task<AdminAccount> GetAdminByAccId(Guid accId);
        Task<AdminAccount> Add(AdminAccount admin);
    }
}
