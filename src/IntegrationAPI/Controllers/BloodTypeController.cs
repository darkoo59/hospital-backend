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

        [HttpPost]
        public IActionResult CheckBloodTypeAvailability([FromBody] BloodTypesDTO bloodTypesDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_bloodTypeService.CheckBloodTypeAvailability(bloodTypesDTO.BloodType, bloodTypesDTO.ApiKey));
        }


    }
}
