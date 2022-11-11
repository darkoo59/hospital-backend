using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalAPI.Mappers
{
    public class VacationRequestMapper : IGenericMapper<VacationRequest, VacationRequestDTO>
    {
        public VacationRequestDTO ToDTO(VacationRequest vacationRequest)
        {
            VacationRequestDTO vacationRequestDTO = new VacationRequestDTO();
            vacationRequestDTO.VacationRequestId = vacationRequest.VacationRequestId;
            vacationRequestDTO.StartDate = vacationRequest.StartDate;
            vacationRequestDTO.EndDate = vacationRequest.EndDate;
            vacationRequestDTO.DoctorId = vacationRequest.DoctorId;
            vacationRequestDTO.IsApproved = vacationRequest.IsApproved;
            vacationRequestDTO.Urgency = vacationRequest.Urgency;
            vacationRequestDTO.Reason = vacationRequest.Reason;
            return vacationRequestDTO;
        }

        public List<VacationRequestDTO> ToDTO(List<VacationRequest> vacationRequests)
        {

            List<VacationRequestDTO> vacationRequestDTOs = new List<VacationRequestDTO>();

            foreach (var vacationRequest in vacationRequests)
            {
                VacationRequestDTO vacationRequestDTO = new VacationRequestDTO();
                vacationRequestDTO.VacationRequestId = vacationRequest.VacationRequestId;
                vacationRequestDTO.StartDate = vacationRequest.StartDate;
                vacationRequestDTO.EndDate = vacationRequest.EndDate;
                vacationRequestDTO.DoctorId = vacationRequest.DoctorId;
                vacationRequestDTO.IsApproved = vacationRequest.IsApproved;
                vacationRequestDTO.Urgency = vacationRequest.Urgency;
                vacationRequestDTO.Reason = vacationRequest.Reason;
                vacationRequestDTOs.Add(vacationRequestDTO);
            }
            return vacationRequestDTOs;
        }

        public VacationRequest ToModel(VacationRequestDTO vacationRequestDTO)
        {
            VacationRequest vacationRequest = new VacationRequest();
            vacationRequest.VacationRequestId = vacationRequestDTO.VacationRequestId;
            vacationRequest.StartDate = vacationRequestDTO.StartDate;
            vacationRequest.EndDate = vacationRequestDTO.EndDate;
            vacationRequest.DoctorId = vacationRequestDTO.DoctorId;
            vacationRequest.IsApproved = vacationRequestDTO.IsApproved;
            vacationRequest.Urgency = vacationRequestDTO.Urgency;
            vacationRequest.Reason = vacationRequestDTO.Reason;
            return vacationRequest;
        }

        public List<VacationRequest> ToModel(List<VacationRequestDTO> vacationRequestsDTOs)
        {
            
            List<VacationRequest> vacationRequests = new List<VacationRequest>();
            
            foreach(var vacationRequestDTO in vacationRequestsDTOs)
            {
                VacationRequest vacationRequest = new VacationRequest();
                vacationRequest.VacationRequestId = vacationRequestDTO.VacationRequestId;
                vacationRequest.StartDate = vacationRequestDTO.StartDate;
                vacationRequest.EndDate = vacationRequestDTO.EndDate;
                vacationRequest.DoctorId = vacationRequestDTO.DoctorId;
                vacationRequest.IsApproved = vacationRequestDTO.IsApproved;
                vacationRequest.Urgency = vacationRequestDTO.Urgency;
                vacationRequest.Reason = vacationRequestDTO.Reason;
                vacationRequests.Add(vacationRequest);
            }
            return vacationRequests;
        }
    }
}
