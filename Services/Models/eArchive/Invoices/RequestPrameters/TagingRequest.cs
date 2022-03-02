using System.Collections.Generic;

namespace Services.Models.eArchive.RequestPrameters
{
    public class TagingRequest
    {
        public List<string> Uuids { get; set; }

        public List<TagingKeyValuePair> Tags { get; set; }
    }
}