using IntegrationLibrary.Features.Blood.Enums;
using Microsoft.IdentityModel.Tokens;
using System;

namespace IntegrationLibrary.Features.EquipmentTenders.Domain
{
    public class TenderRequirement
    {
        public int Id { get; private set; }
        public BloodType BloodType { get; private set; }
        public double Amount { get; private set; }
        public int EquipmentTenderId { get; private set; }
        public TenderRequirement() { }

        public TenderRequirement(BloodType type, double amount)
        {
            if (amount <= 0) throw new InvalidDataException();

            BloodType = type;
            Amount = amount;
        }

        public TenderRequirement(int id, BloodType type, double amount, int tenderId)
        {
            if (amount <= 0) throw new InvalidDataException();

            Id = id;
            BloodType = type;
            Amount = amount;
            EquipmentTenderId = tenderId;
        }

        public class InvalidDataException : Exception
        {
            public InvalidDataException() : base("Provided data was invalid") { }
        }
    }
}
