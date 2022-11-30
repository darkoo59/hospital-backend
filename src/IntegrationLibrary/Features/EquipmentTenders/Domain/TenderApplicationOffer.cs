using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.EquipmentTenders.Domain
{
    public class TenderApplicationOffer
    {
        public int Id { get; private set; }
        public Money Money { get; private set; }
        public string Note { get; private set; }
        public TenderRequirement TenderRequirement { get; private set; }
    }
}
