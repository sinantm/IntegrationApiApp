using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Enums;
using Services.Models;
using Services.Models.eArchive;
using Services.Models.eArchive.Invoices.RequestPrameters;
using Services.Models.eArchive.RequestPrameters;

namespace Services.Interface.eArchive
{
    public interface IInvoiceService
    {
        Task<FileResponseData<byte[]>> InvoicesXml(string uuid);
        
        Task<FileResponseData<byte[]>> InvoicesPdf(string uuid);
        
        Task<FileResponseData<byte[]>> InvoicesExport(InvoicesExportRequest invoicesExportRequest);
        
        Task<string> InvoicesCancel(DocumentCancellationRequest documentCancellationRequest);
        
        Task<string> InvoicesCanceledWithdraw(DocumentCancellationRequest documentCancellationRequest);
        
        Task<string> InvoicesTags(TagingRequest tagingRequest);
        
        Task<Company> InvoicesSaveCompanyInDocument(string uuid);
        
        Task<string> InvoicesBulk(BulkOperationRequest bulkOperationRequest);
        
        Task<InvoicePaginationResult> Invoices(InvoicesPrameters invoicesParameters);
        
        Task<List<Invoice>> InvoicesLast(LastInvoiceParameters lastInvoiceParameters);
        
        Task<InvoicePaginationResult> InvoicesDrafts(DraftInvoicesParameters draftInvoicesParameters);
        
        Task<InvoiceDetail> InvoicesDetail(string uuid);
        
        Task<DespatchDocumentReferencePaginationResult> DespatchesInfo(CommonRequest despatchesRequest);
        
        Task<TaxInfoPaginationResult> InvoicesTaxes(CommonRequest invoicesTaxesRequest);
        
        Task<HistoryPaginationResult> InvoicesHistories(CommonRequest invoicesHistoriesRequest);
        
        Task<MailHistoryPaginationResult> InvoicesMailHistories(CommonRequest invoicesMailHistoriesRequest);
        
        Task<List<string>> InvoicesMailAddresses(string uuid);
        
        Task<SmsHistoryPaginationResult> InvoicesSmsHistories(CommonRequest invoicesSmsHistoriesRequest);
        
        Task<InternetInfo> InvoicesInternetInfos(string uuid);
        
        Task<InvoiceCanceledPaginationResult> InvoicesCanceled(CanceledInvoicesParameters invoicesParameters);
        
        Task<List<InvoiceCanceled>> InvoiceCanceledLast(LastInvoiceCanceledParameters lastInvoiceCanceledParameters);
        
        Task<FileResponseData<byte[]>> InvoicesAttachmentsDownload(AttachmentsParameters attachmentsParameters);
        
        Task<List<Attachment>> InvoicesAttachments(string uuid);
        
        Task<FileResponseData<string>> InvoicesHtml(string uuid);
        
        Task<string> InvoicesEmailSend(EmailSendRequest emailSendRequest);
        
        Task<NotePaginationResult> UserNotes(CommonRequest userNotesRequest);
        
        Task<Note> PostUserNotes(NoteRequest noteRequest,string uuid);
        
        Task<string> PutUserNotes(NotePutParameters notePutParameters,NoteRequest noteRequest);
        
        Task<string> DeleteUserNotes(NotePutParameters noteDeleteParameters,NoteRequest noteRequest);

    }
}