using IntegrationLibrary.Features.BloodBank.Model;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.Domain
{
    public class TenderApplication
    {
        public int Id { get; private set; }
        public string Note { get; private set; }
        public EquipmentTender EquipmentTender { get; private set; }
        public int EquipmentTenderId { get; private set; }
        public ICollection<TenderOffer> TenderOffers { get; private set; }
        public User User { get; private set; }
        public int UserId { get; private set; }
        public bool HasWon { get; private set; }
        public DateTime Finished { get; private set; } 
        
        public TenderApplication() { }
        public TenderApplication(string note, int equipmentTenderId, int userId, ICollection<TenderOffer> tenderOffers)
        {
            Note = note;
            EquipmentTenderId = equipmentTenderId;
            TenderOffers = tenderOffers;
            UserId = userId;

            ValidateFields();
        }

        protected void ValidateFields()
        {
            //validations...
        }

        public void SetHasWon(bool hasWon)
        {
            HasWon = hasWon;
        }

        public void SetDate(DateTime date)
        {
            Finished = date;
        }

        public class InvalidDataException : Exception
        {
            public InvalidDataException() : base("Provided data was invalid") { }
        }
    }
}
