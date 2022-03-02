using System;
using System.Collections.Generic;

namespace Services.Models.eArchive
{
    public class NotePaginationResult
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<Note> Data { get; set; }
    }
}