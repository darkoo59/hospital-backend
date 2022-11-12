using IntegrationLibrary.Features.BloodRequests.DTO;
using IntegrationLibrary.Features.BloodRequests.Model;
using IntegrationLibrary.Features.BloodRequests.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            return Ok(BloodRequestDTO.ToDTOList(_bloodRequestService.GetAll() as List<BloodRequest>));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(new BloodRequestDTO(_bloodRequestService.GetById(id)));
        }

        [HttpPost]
        public IActionResult Create(BloodRequest br)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bloodRequestService.Create(br);

            return Ok();
        }
    }
}
