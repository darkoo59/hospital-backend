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
        void GenerateReport(List<BloodUsageEvidency> evidencies, int days);

        Task<List<BloodUsageEvidency>> GetEvidencies(int days);

        void SendReport(int days);
    }
}
