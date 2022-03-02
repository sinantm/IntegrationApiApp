using System;

namespace Services.Models.eArchive
{
    public class Company
    {
        public string Id { get; set; }
        public string PartyIdentification { get; set; }
        public string PartyName { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string DocumentTemplateId { get; set; }
        public DateTime CreatedAt { get; set; }
        public CompanyAddress DefaultAddress { get; set; }
        
    }
}