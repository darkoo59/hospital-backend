using Microsoft.IdentityModel.Tokens;
using System;

namespace IntegrationLibrary.Features.EquipmentTenders.Domain
{
    public class TenderRequirement
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Amount { get; private set; }
        public int EquipmentTenderId { get; private set; }
        public TenderRequirement() { }

        public TenderRequirement(string name, double amount)
        {
            if (amount <= 0 || name.IsNullOrEmpty()) throw new InvalidDataException();

            Name = name;
            Amount = amount;
        }

        public TenderRequirement(int id, string name, double amount, int tenderId)
        {
            if (amount <= 0 || name.IsNullOrEmpty()) throw new InvalidDataException();

            Id = id;
            Name = name;
            Amount = amount;
            EquipmentTenderId = tenderId;
        }

        public class InvalidDataException : Exception
        {
            public InvalidDataException() : base("Provided data was invalid") { }
        }
    }
}
