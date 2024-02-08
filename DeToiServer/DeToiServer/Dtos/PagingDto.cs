namespace DeToiServer.Dtos
{
    public class PagingDto
    {
        public const int maxPageSize = 20;

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 8;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
