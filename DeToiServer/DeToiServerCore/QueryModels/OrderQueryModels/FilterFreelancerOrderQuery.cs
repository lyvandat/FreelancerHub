namespace DeToiServerCore.QueryModels.OrderQueryModels
{
    public class FilterFreelancerOrderQuery
    {
        public string? SortingCol { get; set; } = string.Empty;
        public string? SortType { get; set; } = string.Empty;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
