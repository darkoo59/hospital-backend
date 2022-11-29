

using IntegrationLibrary.Features.EquipmentTenders.Domain;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.DTO
{
    public class TenderRequirementDTO
    {
        public string Name { get; set; }
        public double Amount { get; set; }

        public static List<TenderRequirement> FromDTOList(ICollection<TenderRequirementDTO> list)
        {
            List<TenderRequirement> temp = new();
            foreach (TenderRequirementDTO req in list)
            {
                temp.Add(new TenderRequirement(req.Name, req.Amount));
            }
            return temp;
        }
    }
}
