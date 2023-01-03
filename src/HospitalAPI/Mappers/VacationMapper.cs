using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class VacationMapper : IGenericMapper<Vacation, VacationDTO>
    {
        public VacationDTO ToDTO(Vacation vacation)
        {
            VacationDTO vacationDTO = new VacationDTO();
            vacationDTO.Id = vacation.Id;
            vacationDTO.StartDate = vacation.StartDate;
            vacationDTO.EndDate = vacation.EndDate;

            return vacationDTO;
        }

        public List<VacationDTO> ToDTO(List<Vacation> vacations)
        {
            List<VacationDTO> vacationDTOs = new List<VacationDTO>();
            foreach (var vacation in vacations)
            {
                VacationDTO vacationDTO = new VacationDTO();
                vacationDTO.Id = vacation.Id;
                vacationDTO.StartDate = vacation.StartDate;
                vacationDTO.EndDate = vacation.EndDate;
                vacationDTOs.Add(vacationDTO);
            }

            return vacationDTOs;
        }

        public Vacation ToModel(VacationDTO vacationDTO)
        {
            return new Vacation(vacationDTO.StartDate, vacationDTO.EndDate);
        }

        public List<Vacation> ToModel(List<VacationDTO> vacationDTOs)
        {
            List<Vacation> vacations = new List<Vacation>();
            foreach (var vacationDTO in vacationDTOs)
            {
                vacations.Add(new Vacation(vacationDTO.StartDate, vacationDTO.EndDate));   
            }

            return vacations;
        }
    }
}
