using System.Collections.Generic;
using Services.Enums.Parameters;

namespace Services.Models.eArchive.RequestPrameters
{
    public class CanceledInvoicesParameters
    {
        public string Company { get; set; }
        public string Uuid { get; set; }
        public string DocumentNumber { get; set; }
        public string StartCreateDate { get; set; }
        public string EndCreateDate { get; set; }
        public SendTypeParameter SendType { get; set; }
        public SalesPlatformParameter SalesPlatform { get; set; }
        public ReportDivisionStatusParameter ReportDivisionStatus { get; set; }
        public string Sort  { get; set; }
        public int PageSize   { get; set; }
        public int Page  { get; set; }
        public string StartDate  { get; set; }
        public string EndDate  { get; set; }
    }
}