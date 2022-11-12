using IntegrationLibrary.Features.BloodRequests.DTO;
using IntegrationLibrary.Features.BloodRequests.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodRequestController : ControllerBase
    {
        private readonly IBloodRequestService _bloodRequestService;
        
        public BloodRequestController(IBloodRequestService service)
        {
            _bloodRequestService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bloodRequestService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_bloodRequestService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create(BloodRequestDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bloodRequestService.Create(dto);

            return Ok();
        }
    }
}
