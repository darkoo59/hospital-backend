using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

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
        public async Task<IActionResult> CheckBloodTypeAvailability([FromQuery] BloodTypesEnum bloodType,
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

    }
}
