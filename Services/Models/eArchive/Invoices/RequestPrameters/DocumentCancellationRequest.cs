using System.Collections.Generic;

namespace Services.Models.eArchive.RequestPrameters
{
    public class DocumentCancellationRequest
    {
        public List<string> Uuids { get; set; }
    }
}