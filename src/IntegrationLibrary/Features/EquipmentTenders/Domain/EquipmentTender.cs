using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.Domain
{
    public class EquipmentTender
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime? ExpiresOn { get; private set; }
        public string Description { get; private set; }
        public ICollection<TenderRequirement> TenderRequirements { get; private set; }
        public ICollection<TenderApplication> TenderApplications { get; private set; }
        public EquipmentTender() { }
        public EquipmentTender(string title, DateTime? expiresOn, string description, ICollection<TenderRequirement> tenderRequirements)
        {
            Title = title;
            ExpiresOn = expiresOn;
            Description = description;
            TenderRequirements = tenderRequirements;
            TenderApplications = new List<TenderApplication>();
            ValidateFields();
        }
        public EquipmentTender(int id, string title, DateTime expiresOn, string description)
        {
            Id = id;
            Title = title;
            ExpiresOn = expiresOn;
            Description = description;
            TenderApplications = new List<TenderApplication>();
            ValidateFields();
        }

        public ICollection<TenderRequirement> GetRequirements()
        {
            return new List<TenderRequirement>(TenderRequirements);
        }

        protected void ValidateFields()
        {
            if (Title.IsNullOrEmpty())
            {
                throw new InvalidDataException();
            }
        }

        public void AddApplication(TenderApplication tenderApplication)
        {
            if(TenderApplications == null)
                TenderApplications = new List<TenderApplication>();
            
            TenderApplications.Add(tenderApplication);
        }

        public class InvalidDataException : Exception { 
            public InvalidDataException() : base("Provided data was invalid") { }
        }
    }
}
