using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodTypeController : ControllerBase
    {
        private readonly IBloodTypeService _bloodTypeService;

        public BloodTypeController(IBloodTypeService bloodTypeService)
        {
            _bloodTypeService = bloodTypeService;
        }

        [HttpGet]
        public IActionResult CheckBloodTypeAvailability([FromQuery] BloodTypesEnum bloodType,
                                                        [FromHeader] string apiKey,
                                                        [FromQuery] float bloodQuantity,
                                                        [FromQuery(Name = "userEmail")] string email)
        {
            Console.WriteLine("U controlleru " + email);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_bloodTypeService.CheckBloodTypeAvailability(bloodType, apiKey, bloodQuantity, email));
        }

    }
}
