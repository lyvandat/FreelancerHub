namespace DeToiServerCore.Models.Accounts
{
    public class FreelanceAccount : ModelBase
    {
        public required Account Account { get; set; }
        public required int AccountId { get; set; }
        public double Rating { get; set; }
        public double Balance { get; set; }
        public string Address { get; set; } = string.Empty;
        public string IdentityNumber { get; set; } = string.Empty;
        public bool IsTeam { get; set; } = false;
        public ICollection<Skill>? Skills { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
