using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Accounts;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.SkillDtos;
using System.ComponentModel.DataAnnotations;

namespace DeToiServer.Dtos.AuthDtos
{
    public class RegisterFreelanceDto
    {
        public string FullName { get; set; } = string.Empty; // auto generated
        public DateOnly? DateOfBirth { get; set; }
        public string CountryCode { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public AddressDto? Address { get; set; }
        public string Gender { get; set; } = GlobalConstant.Gender.Male;
        public bool IsTeam { get; set; } = false;
        public int TeamMemberCount { get; set; } = 1;
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Thiếu CMND/CCCD.")]
        public string IdentityNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Thiếu ảnh mặt trước CMND/CCCD.")]
        public string IdentityCardImage { get; set; } = string.Empty;
        [Required(ErrorMessage = "Thiếu ảnh mặt sau CMND/CCCD.")]
        public string IdentityCardImageBack { get; set; } = string.Empty;

        [Required(ErrorMessage = "Thiếu ảnh đại diện.")]
        public required string Avatar { get; set; }
    }

    public class VerifyFreelanceDto
    {
        public Guid FreelancerId { get; set; }
    }
}
