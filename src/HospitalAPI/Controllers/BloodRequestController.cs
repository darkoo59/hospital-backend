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
    public class BloodRequestController : ControllerBase
    {
        private readonly IBloodRequestService _bloodRequestService;
        private readonly IGenericMapper<BloodRequest, BloodRequestDTO> _bloodRequestMapper;

        public BloodRequestController(IBloodRequestService bloodRequestService, IGenericMapper<BloodRequest, BloodRequestDTO> bloodRequestMapper)
        {
            _bloodRequestService = bloodRequestService;
            _bloodRequestMapper = bloodRequestMapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_bloodRequestMapper.ToDTO(_bloodRequestService.GetAll().ToList()));
        }

        [HttpPost]
        public ActionResult Create(BloodRequestDTO bloodRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BloodRequest bloodRequest = _bloodRequestMapper.ToModel(bloodRequestDTO);
            _bloodRequestService.Create(bloodRequest);
            return CreatedAtAction("GetById", new { id = bloodRequest.BloodRequestId }, bloodRequest);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var bloodRequest = _bloodRequestService.GetById(id);
            if (bloodRequest == null)
            {
                return NotFound();
            }

            return Ok(_bloodRequestMapper.ToDTO(bloodRequest));
        }
    }
}
