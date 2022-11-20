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
    public class InpatientTreatmentsController : ControllerBase
    {
        private readonly IInpatientTreatmentService _inpatientTreatmentService;
        private readonly IGenericMapper<InpatientTreatment, InpatientTreatmentDTO> _inpatientTreatmentMapper;

        public InpatientTreatmentsController(IInpatientTreatmentService inpatientTreatmentService, IGenericMapper<InpatientTreatment, InpatientTreatmentDTO> inpatientTreatmentMapper) {
            _inpatientTreatmentService = inpatientTreatmentService;
            _inpatientTreatmentMapper = inpatientTreatmentMapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_inpatientTreatmentMapper.ToDTO(_inpatientTreatmentService.GetAll().ToList()));
        }

        [HttpPost]
        public ActionResult Create(InpatientTreatmentDTO inpatientTreatmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            InpatientTreatment inpatientTreatment = _inpatientTreatmentMapper.ToModel(inpatientTreatmentDTO);
            _inpatientTreatmentService.Create(inpatientTreatment);
            return CreatedAtAction("GetById", new { id = inpatientTreatment.InpatientTreatmentId }, inpatientTreatment);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var inpatientTreatment = _inpatientTreatmentService.GetById(id);
            if (inpatientTreatment == null)
            {
                return NotFound();
            }

            return Ok(_inpatientTreatmentMapper.ToDTO(inpatientTreatment));
        }
    }
}
