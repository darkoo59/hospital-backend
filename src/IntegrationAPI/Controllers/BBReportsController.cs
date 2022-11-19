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

        [HttpPost("test")]
        public IActionResult TestWindowsService()
        {
            Console.WriteLine("Okinuto u " + DateTime.Now.Hour + " : " + DateTime.Now.Minute);

            return Ok();
        }

    }
}
