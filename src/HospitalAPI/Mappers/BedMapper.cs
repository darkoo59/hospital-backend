using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalAPI.Mappers
{
    public class BedMapper : IGenericMapper<Bed, BedDTO>
    {
        public BedDTO ToDTO(Bed bed)
        {
            BedDTO bedDTO = new BedDTO();
            bedDTO.BedId = bed.BedId;
            bedDTO.Label = bed.Label;
            bedDTO.IsAvailable = bed.IsAvailable;
            return bedDTO;
        }

        public List<BedDTO> ToDTO(List<Bed> beds)
        {
            List<BedDTO> bedDTOs = new List<BedDTO>();
            foreach (var bed in beds) {
                BedDTO bedDTO = new BedDTO();
                bedDTO.BedId = bed.BedId;
                bedDTO.Label = bed.Label;
                bedDTO.IsAvailable = bed.IsAvailable;
                bedDTOs.Add(bedDTO);
            }

            return bedDTOs;
        }

        public Bed ToModel(BedDTO bedDTO)
        {
            Bed bed = new Bed();
            bed.BedId = bedDTO.BedId;
            bed.Label = bedDTO.Label;
            bed.IsAvailable = bedDTO.IsAvailable;
            return bed;
        }

        public List<Bed> ToModel(List<BedDTO> bedDTOs)
        {
            List<Bed> beds = new List<Bed>();
            foreach (var bedDTO in bedDTOs) {
                Bed bed = new Bed();
                bed.BedId = bedDTO.BedId;
                bed.Label = bedDTO.Label;
                bed.IsAvailable = bedDTO.IsAvailable;
                beds.Add(bed);
            }

            return beds;
        }
    }
}
