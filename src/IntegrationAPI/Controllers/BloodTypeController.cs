using IntegrationLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using IntegrationLibrary.Core.Enums;
using IntegrationLibrary.Features.BloodBankReports.Service;
using System.Collections.Generic;
using IntegrationLibrary.Features.BloodBankReports.Model;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodTypeController : ControllerBase
    {
        private readonly IBloodService _bloodTypeService;
        //ZA OBRISATI:
        private readonly IBBReportsService _bbReportsService;

        public BloodTypeController(IBloodService bloodTypeService, IBBReportsService bbReportsService)
        {
            _bloodTypeService = bloodTypeService;
            _bbReportsService = bbReportsService;
        }

        [HttpGet]
        public async Task<IActionResult> CheckBloodTypeAvailability([FromQuery] BloodType bloodType,
                                                        [FromHeader] string apiKey,
                                                        [FromQuery] float bloodQuantity,
                                                        [FromQuery(Name = "userEmail")] string email)
        {
            Console.WriteLine("U controlleru " + email);
            if (!ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("ne valja");
                return BadRequest(ModelState);
            }
            bool data = await _bloodTypeService.CheckBloodTypeAvailability(bloodType, apiKey, bloodQuantity, email);
            return Ok(data);
        }

        //ZA OBRISATI:
        [HttpGet("test")]
        public async Task<IActionResult> GetTestValues()
        {
            List<BloodUsageEvidency> data = await _bbReportsService.GetEvidencies(2);
            _bbReportsService.GenerateReport(data);
            return Ok(data);
        }

    }
}
