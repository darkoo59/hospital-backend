using HospitalAPI.Mappers;
using HospitalAPI.Registration.Dtos;
using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalAPI.Registration.Mappers
{
    public class AllergenMapper : IGenericMapper<Allergen, AllergenDTO>
    {
        public AllergenDTO ToDTO(Allergen allergen)
        {
            AllergenDTO allergenDTO = new AllergenDTO();
            allergenDTO.Name = allergen.Name;
            allergenDTO.AllergenId = allergen.AllergenId;

            return allergenDTO;
        }

        public List<AllergenDTO> ToDTO(List<Allergen> allergens)
        {
            List<AllergenDTO> allergenDTOs = new List<AllergenDTO>();
            foreach (var allergen in allergens)
            {
                AllergenDTO allergenDTO = new AllergenDTO();
                allergenDTO.Name = allergen.Name;
                allergenDTO.AllergenId = allergen.AllergenId;

                allergenDTOs.Add(allergenDTO);
            }
            return allergenDTOs;
        }

        public Allergen ToModel(AllergenDTO allergenDTO)
        {
            Allergen allergen = new Allergen();
            allergen.AllergenId = allergenDTO.AllergenId;
            allergen.Name = allergenDTO.Name;
            

            return allergen;
        }

        public List<Allergen> ToModel(List<AllergenDTO> allergensDTO)
        {
            List<Allergen> allergens = new List<Allergen>();
            foreach (var allergenDTO in allergensDTO)
            {
                Allergen allergen = new Allergen();
                allergen.AllergenId = allergenDTO.AllergenId;
                allergen.Name = allergenDTO.Name;

                allergens.Add(allergen);
            }
            return allergens;
        }
    }
}
