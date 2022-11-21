using IntegrationLibrary.Core.DTO;
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
        public ActionResult SendReport([FromForm] long bankId, [FromForm] int daysIncluded)
        {
            _bbReportsService.SendReport(daysIncluded);

            return Ok();
        }
    }
}
