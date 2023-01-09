using IntegrationLibrary.Features.Blood.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.UrgentBloodOrder.Model
{
    public class UrgentOrder
    {
        public int Id { get; set; }
        public BloodType BloodType { get; set; }

        public double Quantity { get; set; }

        public String BloodBankName { get; set; }

        public DateTime Date { get; set; }

        public UrgentOrder(int id, BloodType bloodType, double quantity, String bloodBankName, DateTime date)
        {
            this.Id = id;
            this.BloodType = bloodType;
            this.Quantity = quantity;
            this.BloodBankName = bloodBankName;
            this.Date = date;
        }

        public UrgentOrder( BloodType bloodType, double quantity, String bloodBankName)
        {
            this.BloodType = bloodType;
            this.Quantity = quantity;
            this.BloodBankName = bloodBankName;
            this.Date = DateTime.Now;
        }
    }
}
