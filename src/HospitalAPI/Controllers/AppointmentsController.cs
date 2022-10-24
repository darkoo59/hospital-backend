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
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly AppointmentMapper _appointmentMapper;

        public AppointmentsController(IAppointmentService appointmentService, AppointmentMapper appointmentMapper)
        {
            _appointmentService = appointmentService;
            _appointmentMapper = appointmentMapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_appointmentMapper.ToDTO(_appointmentService.GetAll().ToList()));
        }

        [HttpPost]
        public ActionResult Create(AppointmentDTO appointmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // zakucano trenutno
            appointmentDTO.DoctorId = 1;
            Appointment appointment = _appointmentMapper.ToModel(appointmentDTO);
            _appointmentService.Create(appointment);
            return CreatedAtAction("GetById", new { id = appointment.AppointmentId }, appointment);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var appointment = _appointmentService.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(_appointmentMapper.ToDTO(appointment));
        }

        [HttpGet("futureAppointments/{doctorId}")]
        public ActionResult GetFutureAppointmentsById(int doctorId)
        {
            return Ok(_appointmentMapper.ToDTO(_appointmentService.GetFutureAppointments(doctorId)));
        }


        // DELETE api/appointments/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var appointment = _appointmentService.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _appointmentService.Delete(appointment);
            return NoContent();
        }


        // PUT api/appintments/2
        [HttpPut("{id}")]
        public ActionResult Update(int id, Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointment.AppointmentId)
            {
                return BadRequest();
            }

            try
            {
                _appointmentService.Update(appointment);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(appointment);
        }


    }
}
