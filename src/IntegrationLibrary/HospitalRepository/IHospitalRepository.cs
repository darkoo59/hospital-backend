using IntegrationLibrary.Features.BloodBankReports.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegrationLibrary.HospitalRepository
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();

        Task<List<BloodUsageEvidency>> GetAllEvidency();
    }
}
