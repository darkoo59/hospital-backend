using IntegrationLibrary.Features.BloodBankReports.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IntegrationAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BBReportsController : ControllerBase
    {
        private readonly IBBReportsService _bbReportsService;

        public BBReportsController(IBBReportsService service)
        {
            _bbReportsService = service;
        }

        [HttpPost("send-report")]
        public ActionResult SendReport([FromForm] int bloodBankId, [FromForm] int reportPeriod)
        {
            _bbReportsService.SendReport(bloodBankId,reportPeriod);

            return Ok();
        }
    }
}
