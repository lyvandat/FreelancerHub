namespace DeToiServer.Dtos.AccountDtos
{
    public record FilterAccountQuery
    {
        public string? Name { get; set; } = string.Empty;
        public string? Role { get; set; } = string.Empty;
        public string? Gender { get; set; } = string.Empty;
        public string? SortingCol { get; set; } = string.Empty;
        public string? SortType { get; set; } = string.Empty;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 8;
    }
}
