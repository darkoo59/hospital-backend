using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.Domain
{
    public class EquipmentTender
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<TenderRequirement> Requirements;
        public ICollection<TenderApplication> TenderApplications { get; set; }
        public EquipmentTender() { }
        public EquipmentTender(string title)
        {
            Title = title;

            ValidateFields();
        }
        public EquipmentTender(int id, string title)
        {
            Id = id;
            Title = title;

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
