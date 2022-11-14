using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Features.BloodBankReports.Model;
using IntegrationLibrary.Features.BloodRequests.Model;

namespace IntegrationLibrary.Features.BloodBankReports.Service
{
    public interface IBBReportsService
    {
        void GenerateReport(List<BloodUsageEvidency> evidencies);

        Task<List<BloodUsageEvidency>> GetEvidencies();
    }
}
