using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class TenderApplicationDTO
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public double TotalCost { get; set; }
        public ICollection<TenderOfferDTO> TenderOffers { get; set; }
     //   public User User { get; set; }
        public bool HasWon { get; set; }


        /*

        public TenderApplicationDTO(TenderApplication ta)
        {
            Id = ta.Id;
            Note = ta.Note;
            User = ta.User;
            TenderOffers = TenderOfferDTO.ToDTOList(ta.TenderOffers);
            HasWon = ta.HasWon;

            foreach (TenderOfferDTO tod in TenderOffers)
                TotalCost += tod.Cost;
        }

        public static ICollection<TenderApplicationDTO> ToDTOList(ICollection<TenderApplication> tas)
        {
            List<TenderApplicationDTO> dtos = new();
            foreach (TenderApplication ta in tas)
            {
                dtos.Add(new TenderApplicationDTO(ta));
            }
            return dtos;
        }


        */
    }
}
