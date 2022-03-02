using Services.Enums.Parameters;

namespace Services.Models.eArchive.RequestPrameters
{
    public class LastInvoiceParameters
    {
        public ArchiveDocumentStatusParameter InvoiceStatus { get; set; }
        public ReportDivisionStatusParameter ReportDivisionStatus { get; set; }
        public bool IncludeCanceledDocuments { get; set; }
        public InvoiceTypeParameter InvoiceTypeCode { get; set; }
    }
}