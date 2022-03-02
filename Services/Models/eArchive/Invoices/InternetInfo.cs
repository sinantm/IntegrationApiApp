using System;

namespace Services.Models.eArchive
{
    public class InternetInfo
    {
        public string WebsiteUri { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethodDescription { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime TransportDate { get; set; }
        public string TransporterRegisterNumber { get; set; }
        public string TransporterName { get; set; }
    }
}