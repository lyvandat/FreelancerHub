namespace DeToiServerCore.QueryModels.PagingQuery
{
    public class PagingQuery
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
