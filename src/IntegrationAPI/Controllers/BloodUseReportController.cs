using IntegrationLibrary.Core.Service;
using IntegrationLibrary.Features.BloodBankReports.Service;
using IntegrationLibrary.Features.BloodRequests.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodUseReportController : ControllerBase
    {
        private readonly IBBReportsService _reportService;

        public BloodUseReportController(IBBReportsService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("send/report")]
        public IActionResult SendReport()
        {
            /*List<BloodUsageEvidency> data = await _bbReportsService.GetEvidencies();
            _bbReportsService.GenerateReport(data);*/
            _reportService.SendReport();
            return Ok("works");
        }


    }
}
