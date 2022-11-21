using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IGenericMapper<Patient, PatientDTO> _patientMapper;


        public PatientsController(IPatientService patientService, IGenericMapper<Patient, PatientDTO> patientMapper)
        {
            _patientService = patientService;
            _patientMapper = patientMapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_patientMapper.ToDTO(_patientService.GetAll().ToList()));
        }

        [HttpGet("getById/{id}")]
        public ActionResult GetById(int id) 
        {
            return Ok(_patientMapper.ToDTO(_patientService.GetById(id)));
        }

        [HttpGet("{id}")]
        public ActionResult GetPatient(int id)
        {
            return Ok(_patientMapper.ToDTO(_patientService.GetById(id)));
        }
    }
}
