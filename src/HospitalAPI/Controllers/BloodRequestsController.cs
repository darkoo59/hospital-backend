using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodRequestsController : ControllerBase
    {
        private readonly IBloodRequestService _service;
        private readonly IGenericMapper<BloodRequest, BloodRequestDTO> _mapper;

        public BloodRequestsController(IBloodRequestService bloodRequestService, IGenericMapper<BloodRequest, BloodRequestDTO> bloodRequestMapper)
        {
            _service = bloodRequestService;
            _mapper = bloodRequestMapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.ToDTO(_service.GetAll().ToList()));
        }

        [HttpPost]
        public async Task<ActionResult> Create(BloodRequestDTO bloodRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BloodRequest bloodRequest = _mapper.ToModel(bloodRequestDTO);
            await _service.Create(bloodRequest);
            return CreatedAtAction("GetById", new { id = bloodRequest.BloodRequestId }, bloodRequest);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var bloodRequest = _service.GetById(id);
            if (bloodRequest == null)
            {
                return NotFound();
            }

            return Ok(_mapper.ToDTO(bloodRequest));
        }
    }
}
