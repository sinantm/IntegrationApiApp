using System.Threading.Tasks;
using Services.Models;

namespace Services.Interface
{
    public interface IUploadsService
    {
        Task<UploadDocumentPreviewResponse> UploadsDocumentPreview(DocumnetPreviewRequest documentPreviewRequest);
        Task<UploadDocumentResponse> UploadsDocument(UploadsDocumentRequest uploadsDocumentRequest);
        
        Task<UploadDocumentResponse> PutUploadsDocument(UploadsDocumentRequest uploadsDocumentRequest,string uuid);
    }
}