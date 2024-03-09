using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Accounts;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.SkillDtos;

namespace DeToiServer.Dtos.AuthDtos
{
    public class RegisterFreelanceDto
    {
        public string IdentityNumber { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty; // auto generated
        public string Avatar { get; set; } = GlobalConstant.CustomerAvtMale; // default
        public DateOnly DateOfBirth { get; set; }
        public string Phone { get; set; } = string.Empty;
        public bool IsTeam { get; set; } = false;
        public int TeamMemberCount { get; set; } = 1;
        public string Description { get; set; } = string.Empty;
        public ICollection<AddressDto>? Address { get; set; }
        public ICollection<SkillDto>? Skills { get; set; }
    }
}
