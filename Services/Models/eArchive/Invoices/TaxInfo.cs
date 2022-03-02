namespace Services.Models.eArchive
{
    public class TaxInfo
    {
        public string TaxTypeCode { get; set; }
        public decimal Percent { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal TaxAmount { get; set; }
    }
}