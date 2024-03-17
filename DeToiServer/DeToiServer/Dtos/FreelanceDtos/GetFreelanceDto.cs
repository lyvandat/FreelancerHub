using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.ServiceProvenDtos;
using DeToiServer.Dtos.SkillDtos;

namespace DeToiServer.Dtos.FreelanceDtos
{
    public class GetFreelanceDto
    {
        public required GetAccountDto Account { get; set; }
        public Guid AccountId { get; set; }
        public double Rating { get; set; }
        public double Balance { get; set; }
        public int OrderCount { get; set; } // orderCount tổng số đơn
        public int LoveCount { get; set; } // loveCount tổng yêu thích
        public int PositiveReviewCount { get; set; } // positiveReviewCount tổng đánh giá ôk.
        public int TotalReviewCount { get; set; }
        public AddressDto? Address { get; set; }
        public string IdentityNumber { get; set; } = string.Empty;
        public bool IsTeam { get; set; } = false;
        public int TeamMemberCount { get; set; }
        public string Description  { get; set; } = string.Empty; // mô tả ngắn.
        public ICollection<SkillDto>? Skills { get; set; }
        public ICollection<GetServiceProvenDto>? ServiceProven { get; set; }
    }

    public class GetFreelanceMatchingDto
    {
        public required GetAccountDto Account { get; set; }
        public Guid AccountId { get; set; }
        public double Rating { get; set; }
        public double Balance { get; set; }
        public int OrderCount { get; set; } // orderCount tổng số đơn
        public int LoveCount { get; set; } // loveCount tổng yêu thích
        public int PositiveReviewCount { get; set; } // positiveReviewCount tổng đánh giá ôk.
        public int TotalReviewCount { get; set; }
        public AddressDto? Address { get; set; }
        public string IdentityNumber { get; set; } = string.Empty;
        public bool IsTeam { get; set; } = false;
        public int TeamMemberCount { get; set; }
        public string Description { get; set; } = string.Empty; // mô tả ngắn.
        public double PreviewPrice { get; set; }
        public ICollection<SkillDto>? Skills { get; set; }
        public ICollection<GetServiceProvenDto>? ServiceProven { get; set; }
    }

    public class GetFreelanceAccountInOrderDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public double Rating { get; set; }
    }
}
