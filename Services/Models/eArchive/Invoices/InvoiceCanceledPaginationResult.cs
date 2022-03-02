using System.Collections.Generic;

namespace Services.Models.eArchive
{
    public class InvoiceCanceledPaginationResult
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<InvoiceCanceled> Data { get; set; }
    }
}