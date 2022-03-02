using System.Collections.Generic;

namespace Services.Models.eArchive
{
    public class HistoryPaginationResult
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<History> Data { get; set; }
    }
}