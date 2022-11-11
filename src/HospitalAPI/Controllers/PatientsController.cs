using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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

        /*// POST api/patients/register
        [HttpPost, Route("register")]
        public ActionResult Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _patientService.Register(patient);
            return CreatedAtAction("GetById", new { id = patient.PatientId }, patient);
        }*/

        // POST api/patients
        [HttpPost]
        public async Task<ActionResult> Register(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _patientService.Register(patient);
            return CreatedAtAction("GetById", new { id = patient.PatientId }, patient);
        }

        // DELETE api/patients/delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var patient = _patientService.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            _patientService.Delete(patient);
            return NoContent();
        }



        [HttpPut("activateAccount/{id}")]
        public ActionResult ActivateAccount(int id)
        {
            var patient = _patientService.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            _patientService.ActivateAccount(patient);
            return Ok();
            //return Redirect("http://localhost:4200/login");
        }

    }
}
