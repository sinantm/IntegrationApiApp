using System;

namespace Services.Models.eArchive
{
    public class SmsHistory
    {
        public string Id { get; set; }
        public DateTime SendedDate { get; set; }
        public DateTime ReadedDate { get; set; }
        public string Telephone { get; set; }
        public bool IsStatusCheck { get; set; }
        public bool IsSend { get; set; }
        public bool IsDownload { get; set; }
        public bool IsView { get; set; }
    }
}