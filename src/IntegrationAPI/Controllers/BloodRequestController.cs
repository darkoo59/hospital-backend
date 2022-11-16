using IntegrationLibrary.Features.BloodBankNews.Model;
using IntegrationLibrary.Features.BloodRequests.DTO;
using IntegrationLibrary.Features.BloodRequests.Enums;
using IntegrationLibrary.Features.BloodRequests.Model;
using IntegrationLibrary.Features.BloodRequests.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public IActionResult Create([FromBody] CreateBloodRequestDTO br)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bloodRequestService.Create(br);

            return Ok();
        }

        [HttpGet("new")]
        public async Task<IActionResult> GetNew()
        {
            List<BloodRequestDTO> temp = await _bloodRequestService.GetAllByState(BloodRequestState.NEW) as List<BloodRequestDTO>;
            return Ok(temp);
        }

        [HttpGet("approved")]
        public async Task<IActionResult> GetApproved()
        {
            List<BloodRequestDTO> temp = await _bloodRequestService.GetAllByState(BloodRequestState.APPROVED) as List<BloodRequestDTO>;
            return Ok(temp);
        }

        [HttpGet("declined")]
        public async Task<IActionResult> GetDeclined()
        {
            List<BloodRequestDTO> temp = await _bloodRequestService.GetAllByState(BloodRequestState.DECLINED) as List<BloodRequestDTO>;
            return Ok(temp);
        }
        [HttpGet("update")]
        public async Task<IActionResult> GetBloodrequestsForUpdate()
        {
            List<BloodRequestDTO> temp = await _bloodRequestService.GetAllByState(BloodRequestState.UPDATE) as List<BloodRequestDTO>;
            return Ok(temp);
        }

        [HttpPatch("approve")]
        public IActionResult ApproveRequest([FromBody] int id)
        {
            _bloodRequestService.ChangeState(id, BloodRequestState.APPROVED);
            return Ok();
        }

        [HttpPatch("decline")]
        public IActionResult DeclineRequest([FromBody] int id)
        {
            _bloodRequestService.ChangeState(id, BloodRequestState.DECLINED);
            return Ok();
        }
    }
}
