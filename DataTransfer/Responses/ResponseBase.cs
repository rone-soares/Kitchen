using System.Collections.Generic;
using DataTransfer.Responses.Helpers;

namespace DataTransfer.Responses
{
    public class ResponseBase<T>
    {
        public int PageNumber { get; set; }
        public int PageRecords { get; set; }
        public int PageSizeRequested { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public IEnumerable<T> Records { get; set; }
        public IEnumerable<SortOptionsResponse> SortOptions { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
    }
}
