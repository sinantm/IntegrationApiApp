namespace Services.Models.eArchive
{
    public class Attachment
    {
        public int Index { get; set; }
        public string FileName { get; set; }
        public string MimeCode { get; set; }
        public byte?[] File { get; set; }
    }
}