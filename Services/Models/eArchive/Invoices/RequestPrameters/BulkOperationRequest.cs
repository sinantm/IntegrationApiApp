using System.Collections.Generic;
using Services.Enums;

namespace Services.Models.eArchive.RequestPrameters
{
    public class BulkOperationRequest
    {
        public BulkOperation Operation { get; set; }

        public List<string> Uuids { get; set; }
    }
}