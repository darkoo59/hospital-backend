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
        private readonly IInpatientTreatmentTherapyService _inpatientTreatmentTherapyService;
        private readonly IGenericMapper<InpatientTreatment, InpatientTreatmentDTO> _inpatientTreatmentMapper;
        private readonly IGenericMapper<InpatientTreatmentTherapy, InpatientTreatmentTherapyDTO> _inpatientTreatmentTherapyMapper;
        private readonly IBedService _bedService;
        public InpatientTreatmentsController(IInpatientTreatmentService inpatientTreatmentService, IBedService bedService, IInpatientTreatmentTherapyService inpatientTreatmentTherapyService, IGenericMapper<InpatientTreatment, InpatientTreatmentDTO> inpatientTreatmentMapper, IGenericMapper<InpatientTreatmentTherapy, InpatientTreatmentTherapyDTO> inpatientTreatmentTherapyMapper) {
            _inpatientTreatmentService = inpatientTreatmentService;
            _inpatientTreatmentTherapyService = inpatientTreatmentTherapyService;
            _bedService = bedService;
            _inpatientTreatmentMapper = inpatientTreatmentMapper;
            _inpatientTreatmentTherapyMapper = inpatientTreatmentTherapyMapper;
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

            _bedService.SetIsNotAvailable(inpatientTreatment.BedId);

            InpatientTreatmentTherapyDTO inpatientTreatmentTherapyDTO = new InpatientTreatmentTherapyDTO();
            inpatientTreatmentTherapyDTO.InpatientTreatmentId = _inpatientTreatmentService.GetInpatientTreatment(inpatientTreatmentDTO.PatientId).InpatientTreatmentId;
            inpatientTreatmentTherapyDTO.MedicineTherapies = new List<MedicineTherapyDTO>();
            inpatientTreatmentTherapyDTO.BloodTherapies = new List<BloodTherapyDTO>();
            _inpatientTreatmentTherapyService.Create(_inpatientTreatmentTherapyMapper.ToModel(inpatientTreatmentTherapyDTO));
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
