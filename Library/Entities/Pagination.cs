using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Entities
{
    public class Pagination<T> : List<T>
    {
        public int CurrentPage { get; protected set; }
        public int TotalPages { get; protected set; }
        public int PageSize { get; protected set; }
        public int TotalCount { get; protected set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public Pagination(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        public static Pagination<T> ToPagination(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new Pagination<T>(items, count, pageNumber, pageSize);
        }
    }
}
