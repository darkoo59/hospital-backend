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
    public class SymptomsController : ControllerBase
    {
        private readonly ISymptomService _service;
        private readonly IGenericMapper<Symptom, SymptomDTO> _mapper;

        public SymptomsController(ISymptomService symptomService, IGenericMapper<Symptom, SymptomDTO> symptomMapper)
        {
            _service = symptomService;
            _mapper = symptomMapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.ToDTO(_service.GetAll().ToList()));
        }

        [HttpGet("{ids}")]
        public ActionResult GetAll(string ids)
        {
            List<int> parameters = new List<int>();
            string[] tokens = ids.Split(",");
            foreach (var token in tokens)
            {
                parameters.Add(Int32.Parse(token));
            }

            return Ok(_mapper.ToDTO(_service.GetAll(parameters)));
        }
    }
}
