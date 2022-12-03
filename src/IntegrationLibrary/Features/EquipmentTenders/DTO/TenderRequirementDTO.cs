

using IntegrationLibrary.Features.EquipmentTenders.Domain;

namespace IntegrationLibrary.Features.EquipmentTenders.DTO
{
    public class TenderRequirementDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public TenderRequirementDTO() { }
        public TenderRequirementDTO(TenderRequirement tr)
        {
            if (tr == null) return;
            Id = tr.Id;
            Name = tr.Name;
            Amount = tr.Amount;
        }
    }
}
