﻿namespace DeToiServerCore.Common.Helper
{
    public class PageList<T>
    {
        public PageList(List<T> items, int count, int pageNum, int pageSize)
        {
            Data = items;
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNum;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public int CurrentPage { get; }
        public int TotalPages { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public IEnumerable<T> Data { get; set; }

        public static PageList<T> ToPageList(IEnumerable<T> source, int pageNum, int pageSize)
        {
            var count = source.Count();
            var item = source.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();

            return new PageList<T>(item, count, pageNum, pageSize);
        }
    }
}
