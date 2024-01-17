using AutoMapper;
using DeToiServerCore.Dtos;
using DeToiServerCore.Models;

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
