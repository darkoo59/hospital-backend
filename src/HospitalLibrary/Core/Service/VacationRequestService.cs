using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Service
{
    public class VacationRequestService : IVacationRequestService
    {
        private readonly IVacationRequestRepository _vacationRequestRepository;
        //private readonly IAppointmentService _appointmentService;
   
        public VacationRequestService(IVacationRequestRepository vacationRequestRepository/*IAppointmentService appointmentService*/)
        {
            _vacationRequestRepository = vacationRequestRepository;
           // _appointmentService = appointmentService;
        }

        

        public IEnumerable<VacationRequest> GetAll()
        {
            return _vacationRequestRepository.GetAll();
        }

        public VacationRequest GetById(int id)
        {
            return _vacationRequestRepository.GetById(id);
        }

        public void Create(VacationRequest vacationRequest)
        {
            _vacationRequestRepository.Create(vacationRequest);
        }
        public void Delete(VacationRequest vacationRequest)
        {
            _vacationRequestRepository.Delete(vacationRequest);
        }

        public bool IsVacationDateStartValid(VacationRequest vacationRequest)
        {
            DateTime now = new DateTime();
            now = DateTime.Now;

            if(vacationRequest.StartDate >= now.AddDays(4))
            {
                return true;
            }
            return false;
        }

        public List<VacationRequest> GetDoctorVacationRequests(int doctorId)
        {
            List<VacationRequest> doctorVacationRequests = new List<VacationRequest>();
            List<VacationRequest> vacationRequests = _vacationRequestRepository.GetAll().ToList();

            foreach (var vacationRequest in vacationRequests)
            {
                if (vacationRequest.DoctorId == doctorId)
                {
                    doctorVacationRequests.Add(vacationRequest);
                }
            }
            return doctorVacationRequests;
        }

        public bool IsValidationRequestValid(VacationRequest vacationRequest)
        {
            bool isValid = true;
            isValid = IsVacationDateStartValid(vacationRequest);
            return isValid;
        }
    
        public void CreateUrgentVacation(int doctorId, DateTime start, DateTime end, VacationRequest vacationRequest)
        {
            ////List<Appointment> appointmentInDataRange = _appointmentService.Get(doctorId, start, end);

            //if (appointmentInDataRange == null)
            //{
            //    vacationRequest.Status = VacationRequestStatus.OnHold;
            //    _vacationRequestRepository.Create(vacationRequest);
            //}

            //if(_appointmentService.ChangeAppointmentDoctor(appointmentInDataRange) == true)
            //{
            //    _vacationRequestRepository.Create(vacationRequest);
            //}
        }
        public void approveVacationRequest(int vacationRequestId)
        {
           _vacationRequestRepository.approveVacationRequest(vacationRequestId);
        
        }
        public void NotapproveVacationRequest(int vacationRequestId)
        {
            _vacationRequestRepository.NotapproveVacationRequest(vacationRequestId);


        }
    }
}