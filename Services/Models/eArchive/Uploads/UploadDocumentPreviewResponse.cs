namespace Services.Models
{
    public class UploadDocumentPreviewResponse
    {
        public string content { get; set; }
        public bool isUsingDefaultTemplate { get; set; }
        public string errorMessage { get; set; }
    }
}