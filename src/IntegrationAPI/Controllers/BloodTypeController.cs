using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using IntegrationLibrary.Features.BloodBankReports.Service;
using System.Collections.Generic;
using IntegrationLibrary.Features.BloodBankReports.Model;
using IntegrationLibrary.Features.Blood.Service;
using IntegrationLibrary.Features.Blood.Enums;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodTypeController : ControllerBase
    {
        private readonly IBloodService _bloodTypeService;

        public BloodTypeController(IBloodService bloodTypeService)
        {
            _bloodTypeService = bloodTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> CheckBloodTypeAvailability([FromQuery] BloodType bloodType,
                                                        [FromHeader] string apiKey,
                                                        [FromQuery] float bloodQuantity,
                                                        [FromQuery(Name = "userEmail")] string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool data = await _bloodTypeService.CheckBloodTypeAvailability(bloodType, apiKey, bloodQuantity, email);
            return Ok(data);
        }

    }
}
