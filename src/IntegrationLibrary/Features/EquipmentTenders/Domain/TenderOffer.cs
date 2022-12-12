

using System;
using IntegrationLibrary.Features.EquipmentTenders.Domain.ValueObjects;

namespace IntegrationLibrary.Features.EquipmentTenders.Domain
{
    public class TenderOffer
    {
        public int Id { get; private set; }
        public Money Money { get; private set; }
        public int TenderRequirementId { get; private set; }
        public TenderRequirement TenderRequirement { get; private set; }
        public int TenderApplicationId { get; private set; }

        public TenderOffer() { }
        public TenderOffer(double cost, int tenderRequirementId)
        {
            Money = new Money(cost);
            TenderRequirementId = tenderRequirementId;

            ValidateFields();
        }

        protected void ValidateFields()
        {
            //validations...
        }

        public class InvalidDataException : Exception
        {
            public InvalidDataException() : base("Provided data was invalid") { }
        }
    }
}
