using IntegrationLibrary.Features.BloodRequests.DTO;
using IntegrationLibrary.Features.BloodRequests.Enums;
using IntegrationLibrary.Features.BloodRequests.Model;
using IntegrationLibrary.Features.BloodRequests.Repository;
using IntegrationLibrary.HospitalRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.BloodRequests.Service
{
    public class BloodRequestService : IBloodRequestService
    {
        private readonly IBloodRequestRepository _bloodRequestRepository;
        private readonly IHospitalRepository _hospitalRepository;
        public BloodRequestService(IBloodRequestRepository bloodRequestRepository, IHospitalRepository hospitalRepository)
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
                    BloodRequestDTO temp = new BloodRequestDTO(br);
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
    }
}
