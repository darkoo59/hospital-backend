using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationRequestController : ControllerBase
    {
        private readonly IVacationRequestService _vacationRequestService;
        private readonly IGenericMapper<VacationRequest,VacationRequestDTO> _vacationRequestMapper;
    
        public VacationRequestController(IVacationRequestService vacationRequestService, IGenericMapper<VacationRequest, VacationRequestDTO> vacationRequestMapper)
        {
            _vacationRequestService = vacationRequestService;
            _vacationRequestMapper = vacationRequestMapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_vacationRequestMapper.ToDTO(_vacationRequestService.GetAll().ToList()));
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var vacationRequest = _vacationRequestService.GetById(id);
            if (vacationRequest == null)
            {
                return NotFound();
            }

            return Ok(_vacationRequestMapper.ToDTO(vacationRequest));
        }

        [HttpPost]
        public ActionResult Create(VacationRequestDTO vacationRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            VacationRequest vacationRequest = _vacationRequestMapper.ToModel(vacationRequestDTO);
            if (_vacationRequestService.IsValidationRequestValid(vacationRequest))
            {
                _vacationRequestService.Create(vacationRequest);
                return CreatedAtAction("GetById", new { id = vacationRequest.VacationRequestId }, vacationRequest);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var vacationRequest = _vacationRequestService.GetById(id);
            if (vacationRequest == null)
            {
                return NotFound();
            }

            _vacationRequestService.Delete(vacationRequest);
            return NoContent();
        }

        [HttpGet("doctorVacationRequests/{doctorId}")]
        public ActionResult GetDoctorVacationRequests(int doctorId)
        {
            return Ok(_vacationRequestMapper.ToDTO(_vacationRequestService.GetDoctorVacationRequests(doctorId)));
        }

        [HttpPost("createUrgentRequest")]
        public ActionResult CreateUrgentVacation(VacationRequestDTO vacationRequestDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            VacationRequest vacationRequest = _vacationRequestMapper.ToModel(vacationRequestDTO);
            if (_vacationRequestService.IsValidationRequestValid(vacationRequest))
            {
                _vacationRequestService.CreateUrgentVacation(vacationRequest.DoctorId, vacationRequest.StartDate, vacationRequest.EndDate, vacationRequest);
                return CreatedAtAction("GetById", new { id = vacationRequest.VacationRequestId }, vacationRequest);
            }
            return null;
        }
        [HttpPut("VacationApproveId/{VacationRequestid}")]
        public ActionResult ApproveRequest(int VacationRequestid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _vacationRequestService.approveVacationRequest(VacationRequestid);

            return Ok(VacationRequestid);
        }

        [HttpPut("VacationNotApproveId/{VacationRequestid}")]
        public ActionResult NotApproveRequest(int VacationRequestid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _vacationRequestService.NotapproveVacationRequest(VacationRequestid);

            return Ok(VacationRequestid);
        }














    }
}
