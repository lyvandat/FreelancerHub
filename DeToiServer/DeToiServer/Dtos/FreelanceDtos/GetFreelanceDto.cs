using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.SkillDtos;
using DeToiServerCore.Models.Accounts;

namespace DeToiServer.Dtos.FreelanceDtos
{
    public class GetFreelanceDto
    {
        public required Guid Id { get; set; }
        public required Account Account { get; set; }
        public required Guid AccountId { get; set; }
        public double Rating { get; set; }
        public double Balance { get; set; }
        public int OrderCount { get; set; } // orderCount tổng số đơn
        public int LoveCount { get; set; } // loveCount tổng yêu thích
        public int PositiveReviewCount { get; set; } // positiveReviewCount tổng đánh giá ôk.
        public AddressDto? Address { get; set; }
        public required string IdentityNumber { get; set; }
        public bool IsTeam { get; set; } = false;
        public ICollection<SkillDto>? Skills { get; set; }
        public required string Description  { get; set; } // mô tả ngắn.
        // serviceProven: IServiceProven[];
    }
}
