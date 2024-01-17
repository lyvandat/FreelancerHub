using AutoMapper;
using DeToiServer.Dtos;

namespace DeToiServerCore
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
