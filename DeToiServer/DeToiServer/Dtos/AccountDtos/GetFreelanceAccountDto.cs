using DeToiServerCore.Models.Accounts;

namespace DeToiServer.Dtos.AccountDtos
{
    public class GetFreelanceAccountDto
    {
        public required Account Account { get; set; }
        public required Guid AccountId { get; set; }
        public double Rating { get; set; }
        public double Balance { get; set; }
        public ICollection<Address>? Address { get; set; }
        public string IdentityNumber { get; set; } = string.Empty;
        public bool IsTeam { get; set; } = false;
        public ICollection<Skill>? Skills { get; set; }
    }
}
