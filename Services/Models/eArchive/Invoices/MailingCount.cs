namespace Services.Models.eArchive
{
    public class MailingCount
    {
        public int SuccedMailCount { get; set; }
        public int FailedMailCount { get; set; }
        public int ReadedMailCount { get; set; }
        public int SuccedSmsCount { get; set; }
        public int FailedSmsCount { get; set; }
        public int ReadedSmsCount { get; set; }
    }
}