using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Features.Blood.DTO;
using IntegrationLibrary.Features.BloodBankReports.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegrationLibrary.HospitalService
{
    public interface IHospitalService
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();

        Task<List<BloodUsageEvidency>> GetAllEvidency();

        Task<string> UpdateBlood(ICollection<BloodDTO> data);
    }
}
