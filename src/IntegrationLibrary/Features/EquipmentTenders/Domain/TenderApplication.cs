using System;
using System.Collections;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.Domain
{
    public class TenderApplication
    {
        public int Id { get; private set; }
        public int Notes { get; private set; }
        public EquipmentTender EquipmentTender { get; private set; }
        public ICollection<TenderApplicationOffer> TenderApplicationOffers { get; private set; }
        
        public TenderApplication() { }
        public TenderApplication(int notes)
        {
            Notes = notes;
        }
    }

    public class InvalidDataException : Exception
    {
        public InvalidDataException() : base("Provided data was invalid") { }
    }
}
