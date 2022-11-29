using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.Domain
{
    public class EquipmentTender
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string Description { get; set; }
        public ICollection<TenderRequirement> Requirements { get; set; }
        public ICollection<TenderApplication> TenderApplications { get; set; }
        public EquipmentTender() { }
        public EquipmentTender(string title)
        {
            Title = title;

            ValidateFields();
        }
        public EquipmentTender(int id, string title, DateTime expiresOn, string description, ICollection<TenderRequirement> requirements)
        {
            Id = id;
            Title = title;
            ExpiresOn = expiresOn;
            Description = description;
            Requirements = requirements;

            ValidateFields();
        }

        public EquipmentTender(string title, DateTime expiresOn, string description, ICollection<TenderRequirement> requirements)
        {
            Title = title;
            ExpiresOn = expiresOn;
            Description = description;
            Requirements = requirements;

            ValidateFields();
        }

        public ICollection<TenderRequirement> GetRequirements()
        {
            return new List<TenderRequirement>(Requirements);
        }

        protected void ValidateFields()
        {
            if (Title.IsNullOrEmpty())
            {
                throw new InvalidDataException();
            }
        }

        public class InvalidDataException : Exception { 
            public InvalidDataException() : base("Provided data was invalid") { }
        }
    }
}
