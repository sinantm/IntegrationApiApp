using System.Collections.Generic;

namespace Services.Models.eArchive
{
    public class EmailSendRequest
    {
        public List<string> Uuids { get; set; }
        public List<string> EmailAdresses { get; set; }
    }   
}