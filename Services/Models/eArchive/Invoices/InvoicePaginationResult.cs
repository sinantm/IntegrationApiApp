using System.Collections.Generic;

namespace Services.Models.eArchive
{
    public class InvoicePaginationResult
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<Invoice> Data { get; set; }
    }
}