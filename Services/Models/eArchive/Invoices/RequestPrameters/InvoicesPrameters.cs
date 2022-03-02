using System;
using System.Collections.Generic;
using Services.Enums;
using Services.Enums.Parameters;

namespace Services.Models.eArchive.RequestPrameters
{
    public class InvoicesPrameters
    {
        public List<string> Tags { get; set; }
        public string UserNote { get; set; }
        public string DocumentNote { get; set; }
        public string DespatchNumber { get; set; }
        public string OrderNumber { get; set; }
        public string Company { get; set; }
        public string Uuid { get; set; }
        public string DocumentNumber { get; set; }
        public string StartCreateDate { get; set; }
        public string EndCreateDate { get; set; }
        public ArchiveDocumentStatusParameter InvoiceStatus { get; set; }
        public ReportDivisionStatusParameter ReportDivisionStatus { get; set; }
        public bool IncludeCanceledDocuments { get; set; }
        public SendTypeParameter SendType { get; set; }
        public SalesPlatformParameter SalesPlatform { get; set; }
        public MailStatusFilterParameter MailStatus { get; set; }
        public InvoiceTypeParameter InvoiceTypeCode { get; set; }
        public SmsStatusFilterParameter SmsStatus { get; set; }
        public string Sort  { get; set; }
        public int PageSize   { get; set; }
        public int Page  { get; set; }
        public string StartDate  { get; set; }
        public string EndDate  { get; set; }
    }
}