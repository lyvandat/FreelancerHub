namespace DeToiServer.Dtos.AccountDtos
{
    public class FilterAccountDto
    {
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string SortingCol { get; set; } = string.Empty;
        public string SortType { get; set; } = string.Empty;

        public FilterAccountDto(
            string name, string role, string gender, string sortingCol, string sortType
        )
        {
            Name = name;
            Role = role;
            Gender = gender;
            SortingCol = sortingCol;
            SortType = sortType;
        }
    }
}
