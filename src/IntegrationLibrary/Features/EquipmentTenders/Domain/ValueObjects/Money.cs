using IntegrationLibrary.Core.Utility;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public double Amount { get; private set; }
        public Money(double amount)
        {
            Amount = amount;

            ValidateFields();
        }

        protected void ValidateFields()
        {
            if (Amount < 0)
            {
                throw new InvalidDataException();
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }

        public class InvalidDataException : Exception
        {
            public InvalidDataException() : base("Provided data was invalid") { }
        }
    }
}
