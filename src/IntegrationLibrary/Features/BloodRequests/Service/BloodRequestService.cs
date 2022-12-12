using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Features.BloodRequests.DTO;
using IntegrationLibrary.Features.BloodRequests.Enums;
using IntegrationLibrary.Features.BloodRequests.Model;
using IntegrationLibrary.Features.BloodRequests.Repository;
using IntegrationLibrary.HospitalService;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.BloodRequests.Service
{
    public class BloodRequestService : IBloodRequestService
    {
        private readonly IBloodRequestRepository _bloodRequestRepository;
        private readonly IHospitalService _hospitalRepository;
        private static readonly HttpClient _httpClient = new HttpClient();
        public BloodRequestService(IBloodRequestRepository bloodRequestRepository, IHospitalService hospitalRepository)
        {
            _bloodRequestRepository = bloodRequestRepository;
            _hospitalRepository = hospitalRepository;
        }

        public void Create(CreateBloodRequestDTO dto)
        {
            BloodRequest br = new()
            {
                Id = dto.BloodRequestId,
                BloodType = dto.BloodType,
                QuantityInLiters = dto.QuantityInLiters,
                ReasonForRequest = dto.ReasonForRequest,
                DoctorId = dto.DoctorId,
                State = BloodRequestState.NEW
            };
            _bloodRequestRepository.Create(br);
        }

        public IEnumerable<BloodRequest> GetAll()
        {
            return _bloodRequestRepository.GetAll();
        }

        public async Task<IEnumerable<BloodRequestDTO>> GetAllByState(BloodRequestState state)
        {
            List<Doctor> doctors = await _hospitalRepository.GetAllDoctors() as List<Doctor>;

            List<BloodRequestDTO> res = new();
            foreach (BloodRequest br in GetAll())
            {
                if (br.State == state)
                {
                    BloodRequestDTO temp = new(br);
                    Doctor d = doctors.FirstOrDefault(x => x.DoctorId == br.DoctorId);
                    if(d != null)
                    {
                        temp.Doctor = d;
                    }
                    res.Add(temp);
                }
            }

            return res;
        }

        public BloodRequest GetById(int id)
        {
            return _bloodRequestRepository.GetById(id);
        }

        public void ChangeState(int id, BloodRequestState newState)
        {
            BloodRequest br = GetById(id);
            if (br == null) 
                throw new System.Exception("Blood request with given ID has not been found.");
            if (br.State != BloodRequestState.NEW)
                throw new System.Exception("Invalid action");

            br.State = newState;
            GetBloodSupply(br);
            _bloodRequestRepository.Update(br);
        }

        public void RequestAdjustment(RequestAdjustmentDTO dto)
        {
            BloodRequest br = GetById(dto.Id);
            if (br == null)
                throw new System.Exception("Blood request with given ID has not been found.");
            if (br.State != BloodRequestState.NEW)
                throw new System.Exception("Invalid action");
            br.State = BloodRequestState.UPDATE;
            br.ReasonForAdjustment = dto.Reason;
            _bloodRequestRepository.Update(br);
        }

        public IEnumerable<BloodRequest> GetAllByDoctorId(int doctorId)
        {
            List<BloodRequest> temp = new();
            foreach (BloodRequest br in GetAll())
            {   if(br.DoctorId == doctorId)
                {
                    temp.Add(br);
                }

            }
            return temp;
        }
        public IEnumerable<BloodRequest> GetAllForAdjustmentByDoctorId(int doctorId)
        {
            List<BloodRequest> temp = new();
            foreach (BloodRequest br in GetAll())
            {
                if (br.DoctorId == doctorId && br.State == BloodRequestState.UPDATE)
                {
                    temp.Add(br);
                }

            }
            return temp;
        }

        public void UpdateBloodRequestForAdjustment(UpdateBloodRequestDTO dto)
        {
            BloodRequest br = GetById(dto.Id);
            if (br == null)
                throw new System.Exception("Blood request with given ID has not been found.");
            if (br.State != BloodRequestState.UPDATE)
                throw new System.Exception("Invalid action");

            br.State = BloodRequestState.NEW;
            br.ReasonForRequest = dto.NewReason;
            br.QuantityInLiters = dto.NewQuantity;
            br.ReasonForAdjustment = null;

            _bloodRequestRepository.Update(br);
        }

        public async void GetBloodSupply(BloodRequest br)
        {
            var url = "http://localhost:6555/api/blood-request";
            await _httpClient.PostAsJsonAsync(url, br);
        }
    }
}
