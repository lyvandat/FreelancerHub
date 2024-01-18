using AutoMapper;
using DeToiServer.Dtos;

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
