using IntegrationAPI.Authorization;
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
        #region setup
        private readonly IBloodRequestService _bloodRequestService;
        
        public BloodRequestController(IBloodRequestService service)
        {
            _bloodRequestService = service;
        }
        #endregion

        #region PUBLIC API

        /// <summary>
        /// Creates the new blood request from the DTO.
        /// </summary>
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

        /// <summary>
        /// Route for getting all blood requests that belong to the doctor with the given Id.
        /// </summary>
        [HttpGet("doctor")]
        public IActionResult GetAllByDoctorId(int id)
        {
            return Ok(_bloodRequestService.GetAllByDoctorId(id));
        }

        /// <summary>
        /// Route for getting all blood requests marked for adjustment that belong to the doctor with the given Id.
        /// </summary>
        [HttpGet("doctor/adjustments")]
        public IActionResult GetAllForAdjustmentByDoctorId(int id)
        {
            return Ok(_bloodRequestService.GetAllForAdjustmentByDoctorId(id));
        }

        /// <summary>
        /// This route will update the reason, quantity and state for the blood request that has the same Id as provided in the DTO.
        /// If the blood request hasn't been previously marked for adjustment, exception will be thrown.
        /// </summary>
        [HttpPatch("update")]
        public IActionResult UpdateBloodRequestForAdjustment(UpdateBloodRequestDTO dto)
        {
            _bloodRequestService.UpdateBloodRequestForAdjustment(dto);
            return Ok();
        }

        #endregion

        #region INTERNAL API
        [HttpGet]
        public IActionResult GetAll()
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            return Ok(BloodRequestDTO.ToDTOList(_bloodRequestService.GetAll() as List<BloodRequest>));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            return Ok(new BloodRequestDTO(_bloodRequestService.GetById(id)));
        }

        [HttpGet("new")]
        public async Task<IActionResult> GetNew()
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            List<BloodRequestDTO> temp = await _bloodRequestService.GetAllByState(BloodRequestState.NEW) as List<BloodRequestDTO>;
            return Ok(temp);
        }

        [HttpGet("approved")]
        public async Task<IActionResult> GetApproved()
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            List<BloodRequestDTO> temp = await _bloodRequestService.GetAllByState(BloodRequestState.APPROVED) as List<BloodRequestDTO>;
            return Ok(temp);
        }

        [HttpGet("declined")]
        public async Task<IActionResult> GetDeclined()
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            List<BloodRequestDTO> temp = await _bloodRequestService.GetAllByState(BloodRequestState.DECLINED) as List<BloodRequestDTO>;
            return Ok(temp);
        }
        [HttpGet("update")]
        public async Task<IActionResult> GetBloodrequestsForUpdate()
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            List<BloodRequestDTO> temp = await _bloodRequestService.GetAllByState(BloodRequestState.UPDATE) as List<BloodRequestDTO>;
            return Ok(temp);
        }

        [HttpPatch("approve")]
        public IActionResult ApproveRequest([FromBody] int id)
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            _bloodRequestService.ChangeState(id, BloodRequestState.APPROVED);
            return Ok();
        }

        [HttpPatch("decline")]
        public IActionResult DeclineRequest([FromBody] int id)
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            _bloodRequestService.ChangeState(id, BloodRequestState.DECLINED);
            return Ok();
        }

        [HttpPatch("adjustment")]
        public IActionResult RequestAdjustment([FromBody] RequestAdjustmentDTO dto)
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            _bloodRequestService.RequestAdjustment(dto);
            return Ok();
        }

        #endregion
    }
}
