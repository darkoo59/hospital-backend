using HospitalAPI.Mappers;
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
        private readonly PatientMapper _patientMapper;

        public PatientsController(IPatientService patientService, PatientMapper patientMapper)
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
    }
}
