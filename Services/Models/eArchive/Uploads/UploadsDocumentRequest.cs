using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Services.Models
{
    public class UploadsDocumentRequest
    {
        public byte[] File { get; set; }
        public bool IsDirectSend { get; set; }
        public string PreviewType { get; set; }
        public string DocumentTemplate { get; set; }
        public string BranchCode { get; set; }
        public string SourceApp { get; set; }
        public string SourceAppRecordId { get; set; }
    }
}