using IntegrationLibrary.Features.EquipmentTenders.Domain;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.DTO.UserDTO
{
    public class UserTenderApplicationDTO
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public double TotalCost { get; set; }
        public UserEquipmentTenderDTO EquipmentTender { get; set; }
        public ICollection<TenderOfferDTO> TenderOffers { get; set; }
        public bool HasWon { get; set; }

        public UserTenderApplicationDTO(TenderApplication ta)
        {
            Id = ta.Id;
            Note = ta.Note;
            EquipmentTender = new UserEquipmentTenderDTO(ta.EquipmentTender);
            TenderOffers = TenderOfferDTO.ToDTOList(ta.TenderOffers);
            HasWon = ta.HasWon;

            foreach (TenderOfferDTO tod in TenderOffers)
                TotalCost += tod.Cost;
        }

        public static ICollection<UserTenderApplicationDTO> ToDTOList(ICollection<TenderApplication> tas)
        {
            List<UserTenderApplicationDTO> dtos = new();
            foreach (TenderApplication ta in tas)
            {
                dtos.Add(new UserTenderApplicationDTO(ta));
            }
            return dtos;
        }
    }
}
