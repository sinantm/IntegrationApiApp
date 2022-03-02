using System;

namespace Services.Models.eArchive
{
    public class CompanyAddress
    {
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public string Title { get; set; }
        
        public string StreetName { get; set; }
        
        public string CitySubdivisionName { get; set; }

        public string CityName { get; set; }

        public string CountryName { get; set; }
        
        public string PostalZone { get; set; }
        
        public string Telephone { get; set; }
        
        public string Telefax { get; set; }
        
        public string ElectronicMail { get; set; }
        
        public string WebsiteUri { get; set; }
        
        public string PartyTaxSchemeName { get; set; }
        
        public bool IsDefault { get; set; }
    }
}