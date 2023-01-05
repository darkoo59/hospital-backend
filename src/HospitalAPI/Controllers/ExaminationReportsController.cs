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
    public class ExaminationReportsController : ControllerBase
    {
        private readonly IExaminationReportService _service;
        private readonly IGenericMapper<ExaminationReport, ExaminationReportDTO> _mapper;

        public ExaminationReportsController(IExaminationReportService examinationReportService, IGenericMapper<ExaminationReport, ExaminationReportDTO> mapper)
        {
            _service = examinationReportService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Create(ExaminationReportDTO examinationReportDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ExaminationReport examinationReport = _mapper.ToModel(examinationReportDTO);
            _service.Create(examinationReport);
            return CreatedAtAction("GetById", new { id = examinationReport.Id }, examinationReport);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.ToDTO(_service.GetAll().ToList()));
        }

        [HttpGet("search/{searchText}")]
        public ActionResult Search(String searchText)
        {
          return Ok(_mapper.ToDTO(_service.Search(searchText).ToList()));
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var examinationReport = _service.GetById(id);
            if (examinationReport == null)
            {
                return NotFound();
            }

            return Ok(_mapper.ToDTO(examinationReport));
        }
    }
}
