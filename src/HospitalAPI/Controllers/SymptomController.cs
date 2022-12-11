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
    public class SymptomController : ControllerBase
    {
        private readonly ISymptomService _service;
        private readonly IGenericMapper<Symptom, SymptomDTO> _mapper;

        public SymptomController(ISymptomService symptomService, IGenericMapper<Symptom, SymptomDTO> symptomMapper)
        {
            _service = symptomService;
            _mapper = symptomMapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.ToDTO(_service.GetAll().ToList()));
        }
    }
}
