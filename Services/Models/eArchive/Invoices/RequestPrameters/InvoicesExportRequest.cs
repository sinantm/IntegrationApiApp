using System.Collections.Generic;
using Services.Enums;

namespace Services.Models.eArchive.RequestPrameters
{
    public class InvoicesExportRequest
    {
        public FileType FileType { get; set; }
        
        public List<string> Uuids { get; set; }
    }
}