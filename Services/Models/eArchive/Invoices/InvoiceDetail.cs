using System;
using System.Collections.Generic;
using Services.Enums;

namespace Services.Models.eArchive
{
    public class InvoiceDetail
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime IssueDate { get; set; }
        public AccountingCustomerParty AccountingCustomerParty { get; set; } 
        public List<string> Branches { get; set; }
        public string DocumentNumber { get; set; }
        public InvoiceTypeCode InvoiceTypeCode { get; set; }
        public string DocumentCurrencyCode { get; set; }
        public decimal AllowanceTotalAmount { get; set; }
        public decimal ChargeTotalAmount { get; set; }
        public decimal TaxExclusiveAmount { get; set; }
        public decimal TaxTotalAmount { get; set; }
        public decimal PayableAmount { get; set; }
        public decimal PricingExchangeCalculationRate { get; set; }
        public string ErrorDescription { get; set; }
        public bool IsPrinted { get; set; }
        public bool IsInternet { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime? CancelDate { get; set; }
        public SendType SendType { get; set; }
        public TransferType TransferType { get; set; }
        public ArchiveDocumentStatus ArchiveDocumentStatus { get; set; }
        public EArchiveDocumentsReportDivisionStatus ReportDivisionStatus { get; set; }
    }
}   