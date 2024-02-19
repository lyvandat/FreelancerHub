namespace DeToiServerCore.QueryModels.ServiceTypeQueryModels
{
    public class FilterServiceTypeQuery
    {
        public string Name { get; set; } = string.Empty;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 8;
    }
}
