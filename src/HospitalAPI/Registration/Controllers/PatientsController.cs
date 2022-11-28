using HospitalAPI.Mappers;
using HospitalAPI.Registration.Dtos;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Registration.Service;
using HospitalLibrary.Security;
using HospitalLibrary.SharedModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IAllergenService _allergenService;
        private readonly IDoctorService _doctorService;
        private readonly IGenericMapper<Patient, PatientDTO> _patientMapper;
        private readonly IGenericMapper<User, PatientDTO> _userMapper;
        private readonly IGenericMapper<MedicalRecord, PatientDTO> _medicalRecordMapper;
        private Patient patient;
        private User user;
        private MedicalRecord medicalRecord;
        private ICollection<Allergen> allergens;

        public PatientsController(
            IPatientService patientService, 
            IAllergenService allergenService,
            IDoctorService doctorService,
            IGenericMapper<Patient, PatientDTO> patientMapper,
            IGenericMapper<User, PatientDTO> userMapper,
            IGenericMapper<MedicalRecord, PatientDTO> medicalRecordMapper
            )
        {
            _patientService = patientService;
            _patientMapper = patientMapper;
            _userMapper = userMapper;
            _medicalRecordMapper = medicalRecordMapper;
            _allergenService = allergenService;
            _doctorService = doctorService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_patientMapper.ToDTO(_patientService.GetAll().ToList()));
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_patientMapper.ToDTO(_patientService.GetById(id)));
        }

        // POST api/patients
        [HttpPost]
        public async Task<ActionResult> Register(PatientDTO patientDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user = _userMapper.ToModel(patientDTO);

            patient = _patientMapper.ToModel(patientDTO);
            //patient.Doctors.Add(_doctorService.GetById(patientDTO.DoctorsId));

            medicalRecord = _medicalRecordMapper.ToModel(patientDTO);

            //foreach(int aid in patientDTO.Allergens)
            //{
            //    medicalRecord.Allergens.Add(_allergenService.GetById(aid));
            //}

            //foreach(int aid in patientDTO.Allergens)
            //{
            //    allergens.Add(_allergenService.GetById(aid));
            //}

            await _patientService.Register(user, patient, medicalRecord);

            return CreatedAtAction("GetById", new { id = user.UserId }, user);
            
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
