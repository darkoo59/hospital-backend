using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                                                                    string apiKey,
                                                                    float bloodQuantity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_bloodTypeService.CheckBloodTypeAvailability(bloodType, apiKey, bloodQuantity));
        }


    }
}
