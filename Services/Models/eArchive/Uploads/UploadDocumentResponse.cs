namespace Services.Models
{
    public class UploadDocumentResponse
    {
        public string uuid { get; set; }
        public string documentNumber { get; set; }
        public UploadDocumentPreviewResponse preview { get; set; }
    }
}