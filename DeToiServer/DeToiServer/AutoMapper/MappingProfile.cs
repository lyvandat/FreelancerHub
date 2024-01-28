using AutoMapper;
using DeToiServer.Dtos;
using DeToiServerCore.Models.Accounts;

namespace DeToiServer.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Account
            CreateMap<Account, AccountDto>().ReverseMap();

            #endregion

        }
    }
}
