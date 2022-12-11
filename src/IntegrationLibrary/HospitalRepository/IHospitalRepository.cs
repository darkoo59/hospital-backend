using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Features.BloodBankReports.Model;
using IntegrationLibrary.Features.UrgentBloodOrder.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegrationLibrary.HospitalRepository
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();

        Task<List<BloodUsageEvidency>> GetAllEvidency();

        void UpdateBloodQuantity(int bloodType, float quantity);
    }
}
