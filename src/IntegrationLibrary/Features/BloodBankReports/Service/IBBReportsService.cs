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
        String GenerateReport(List<BloodUsageEvidency> evidencies, int days);

        List<BloodUsageEvidency> GetEvidencies(int days);

        void SendReport(int days);
        void SendReportInRequest(String filePath);
    }
}
