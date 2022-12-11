using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Features.Blood.DTO;
using IntegrationLibrary.Features.BloodBankReports.Model;
using IntegrationLibrary.Features.UrgentBloodOrder.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegrationLibrary.HospitalService
{
    public interface IHospitalService
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();

        Task<List<BloodUsageEvidency>> GetAllEvidency();

        void UpdateBloodQuantity(int bloodType, float quantity);
        
        Task<string> UpdateBlood(ICollection<BloodDTO> data);
    }
}
