using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.ServiceProvenDtos;
using DeToiServer.Dtos.SkillDtos;
using DeToiServerCore.Models.Accounts;

namespace DeToiServer.Dtos.FreelanceDtos
{
    public class GetFreelanceDto
    {
        public Guid Id { get; set; }
        public required Account Account { get; set; }
        public Guid AccountId { get; set; }
        public double Rating { get; set; }
        public double Balance { get; set; }
        public int OrderCount { get; set; } // orderCount tổng số đơn
        public int LoveCount { get; set; } // loveCount tổng yêu thích
        public int PositiveReviewCount { get; set; } // positiveReviewCount tổng đánh giá ôk.
        public AddressDto? Address { get; set; }
        public string IdentityNumber { get; set; } = string.Empty;
        public bool IsTeam { get; set; } = false;
        public string Description  { get; set; } = string.Empty; // mô tả ngắn.
        public ICollection<SkillDto>? Skills { get; set; }
        public ICollection<GetServiceProvenDto>? ServiceProven { get; set; }
    }

    public class GetFreelanceMatchingDto
    {
        public Guid Id { get; set; }
        public required Account Account { get; set; }
        public Guid AccountId { get; set; }
        public double Rating { get; set; }
        public double Balance { get; set; }
        public int OrderCount { get; set; } // orderCount tổng số đơn
        public int LoveCount { get; set; } // loveCount tổng yêu thích
        public int PositiveReviewCount { get; set; } // positiveReviewCount tổng đánh giá ôk.
        public AddressDto? Address { get; set; }
        public string IdentityNumber { get; set; } = string.Empty;
        public bool IsTeam { get; set; } = false;
        public string Description { get; set; } = string.Empty; // mô tả ngắn.
        public double PreviewPrice { get; set; }
        public ICollection<SkillDto>? Skills { get; set; }
        public ICollection<GetServiceProvenDto>? ServiceProven { get; set; }
    }
}
