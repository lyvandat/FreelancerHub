namespace DeToiServerCore.QueryModels.OrderQueryModels
{
    public class FilterFreelancerOrderQuery
    {
        public string? SortingCol { get; set; } = string.Empty;
        public string? SortType { get; set; } = string.Empty;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class FilterFreelancerIncomingOrderQuery
    {
        public Guid FreelancerId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
