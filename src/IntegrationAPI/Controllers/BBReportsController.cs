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
        public IActionResult SendReport([FromForm] long bankId, [FromForm] int daysIncluded)
        {
            Console.WriteLine("Okinuto u " + DateTime.Now.Hour + " : " + DateTime.Now.Minute);
            Console.WriteLine("ID Banke: " + bankId.ToString() + " //// Dani:" +  daysIncluded.ToString());
            _bbReportsService.SendReport(daysIncluded);

            return Ok();
        }
    }
}
