using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class EquipmentTender
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public string Description { get; set; }

        public TenderState State { get; set; }
        public ICollection<TenderRequirement> Requirements { get; set; }
    }
}
