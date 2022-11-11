using HospitalAPI.Dtos;
using HospitalLibrary.Core.Enums;
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
            if(vacationRequest.Status == VacationRequestStatus.Approved)
            {
                vacationRequestDTO.Status = "Approved";
            }
            else if(vacationRequest.Status == VacationRequestStatus.NotApproved)
            {
                vacationRequestDTO.Status = "NotApproved";
            }
            else
            {
                vacationRequestDTO.Status = "OnHold";
            }
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
                if (vacationRequest.Status == VacationRequestStatus.Approved)
                {
                    vacationRequestDTO.Status = "Approved";
                }
                else if (vacationRequest.Status == VacationRequestStatus.NotApproved)
                {
                    vacationRequestDTO.Status = "NotApproved";
                }
                else
                {
                    vacationRequestDTO.Status = "OnHold";
                }
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
            if (vacationRequestDTO.Status.Equals("Approved"))
            {
                vacationRequest.Status = VacationRequestStatus.Approved;
            }
            else if (vacationRequestDTO.Status.Equals("NotApproved"))
            {
                vacationRequest.Status = VacationRequestStatus.NotApproved;
            }
            else
            {
                vacationRequest.Status = VacationRequestStatus.OnHold;
            }
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
                if (vacationRequestDTO.Status.Equals("Approved"))
                {
                    vacationRequest.Status = VacationRequestStatus.Approved;
                }
                else if (vacationRequestDTO.Status.Equals("NotApproved"))
                {
                    vacationRequest.Status = VacationRequestStatus.NotApproved;
                }
                else
                {
                    vacationRequest.Status = VacationRequestStatus.OnHold;
                }
                vacationRequest.Urgency = vacationRequestDTO.Urgency;
                vacationRequest.Reason = vacationRequestDTO.Reason;
                vacationRequests.Add(vacationRequest);
            }
            return vacationRequests;
        }
    }
}
