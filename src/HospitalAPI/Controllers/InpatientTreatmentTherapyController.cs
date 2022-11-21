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
    public class InpatientTreatmentTherapyController : ControllerBase
    {
        private readonly IInpatientTreatmentTherapyService _inpatientTreatmentTherapyService;
        private readonly IBloodService _bloodService;
        private readonly IGenericMapper<InpatientTreatmentTherapy, InpatientTreatmentTherapyDTO> _inpatientTreatmentTherapyMapper;

        public InpatientTreatmentTherapyController(IInpatientTreatmentTherapyService inpatientTreatmentTherapyService, IBloodService bloodService, IGenericMapper<InpatientTreatmentTherapy, InpatientTreatmentTherapyDTO> inpatientTreatmentTherapyMapper)
        {
            _inpatientTreatmentTherapyService = inpatientTreatmentTherapyService;
            _bloodService = bloodService;
            _inpatientTreatmentTherapyMapper = inpatientTreatmentTherapyMapper;
        }

        [HttpPost]
        public ActionResult Create(InpatientTreatmentTherapyDTO inpatientTreatmentTherapyDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            InpatientTreatmentTherapy inpatientTreatmentTherapy = _inpatientTreatmentTherapyMapper.ToModel(inpatientTreatmentTherapyDTO);
            _inpatientTreatmentTherapyService.Create(inpatientTreatmentTherapy);
            return CreatedAtAction("GetById", new { id = inpatientTreatmentTherapy.InpatientTreatmentTherapyId }, inpatientTreatmentTherapy);
        }

        [HttpGet("{id}")]
        public ActionResult GetInpatientTreatmentTherapy(int id)
        {
            var inpatientTreatmentTherapy = _inpatientTreatmentTherapyService.GetInpatientTreatmentTherapy(id);
            if (inpatientTreatmentTherapy == null)
            {
                return NotFound();
            }

            return Ok(_inpatientTreatmentTherapyMapper.ToDTO(inpatientTreatmentTherapy));
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, InpatientTreatmentTherapyDTO inpatientTreatmentTherapyDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inpatientTreatmentTherapyDTO.InpatientTreatmentTherapyId)
            {
                return BadRequest();
            }

            /*if (_bloodService.IsThereEnoughBlood(_inpatientTreatmentTherapyMapper.ToModel(inpatientTreatmentTherapyDTO).BloodTherapies.Last()))
            {
                return BadRequest();
            }*/

            try
            {
                _inpatientTreatmentTherapyService.Update(_inpatientTreatmentTherapyMapper.ToModel(inpatientTreatmentTherapyDTO));
            }
            catch
            {
                return BadRequest();
            }

            return Ok(_inpatientTreatmentTherapyMapper.ToModel(inpatientTreatmentTherapyDTO));
        }
    }
}
