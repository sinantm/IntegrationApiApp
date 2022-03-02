namespace Services.Models.eArchive.RequestPrameters
{
    public class DraftInvoicesParameters
    {
        public string Company { get; set; }
        public string Uuid { get; set; }
        public string DocumentNumber { get; set; }
        public string Sort  { get; set; }
        public int PageSize   { get; set; }
        public int Page   { get; set; }
    }
}