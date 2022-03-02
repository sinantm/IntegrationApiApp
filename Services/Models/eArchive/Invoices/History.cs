using System;
using Services.Enums;

namespace Services.Models.eArchive
{
    public class History
    {
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; }
        public string ClientIp { get; set; }
        public string Message { get; set; }
        public EntryType EntryType { get; set; }
    }
}