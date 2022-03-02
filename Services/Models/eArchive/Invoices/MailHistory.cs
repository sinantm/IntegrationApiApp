using System;

namespace Services.Models.eArchive
{
    public class MailHistory
    {
        public string Id { get; set; }
        public DateTime SendedDate { get; set; }
        public DateTime ReadedDate { get; set; }
        public string ReceiverMail { get; set; }
        public bool IsSend { get; set; }
        public bool IsRead { get; set; }
        public bool IsDownload { get; set; }
        public bool IsView { get; set; }
    }
}