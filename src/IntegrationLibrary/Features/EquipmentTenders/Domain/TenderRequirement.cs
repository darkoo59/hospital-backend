using IntegrationLibrary.Core.Utility;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.Domain
{
    public class TenderRequirement : ValueObject
    {
        public string Name { get; }
        public double Amount { get; }

        public TenderRequirement(string name, double amount)
        {
            if (amount <= 0 || name.IsNullOrEmpty()) throw new InvalidDataException();

            Name = name;
            Amount = amount;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Amount;
        }

        public class InvalidDataException : Exception
        {
            public InvalidDataException() : base("Provided data was invalid") { }
        }
    }
}
