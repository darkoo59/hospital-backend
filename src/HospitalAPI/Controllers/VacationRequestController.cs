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





    }
}
