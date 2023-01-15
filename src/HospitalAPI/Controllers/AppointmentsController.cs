using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IGenericMapper<Appointment, AppointmentDTO> _appointmentMapper;
        private readonly INotificationService _notificationService;
        private readonly IPhysicianScheduleService _physicianScheduleService;
        private readonly IDoctorService _doctorService;
        private readonly IGenericMapper<Doctor, DoctorDTO> _doctorMapper;

        public AppointmentsController(IGenericMapper<Appointment, AppointmentDTO> appointmentMapper, INotificationService notificationService, IPhysicianScheduleService physicianScheduleService, IDoctorService doctorService, IGenericMapper<Doctor, DoctorDTO> doctorMapper)
        {
            _appointmentMapper = appointmentMapper;
            _notificationService = notificationService;
            _physicianScheduleService = physicianScheduleService;
            _doctorService = doctorService;
            _doctorMapper = doctorMapper;
        }

    //    [HttpGet]
    //    public ActionResult GetAll()
    //    {
    //        return Ok(_appointmentMapper.ToDTO(_appointmentService.GetAll().ToList()));
    //    }

        [HttpPost("schedule")]
        public ActionResult Create(AppointmentDTO appointmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Appointment appointment = _appointmentMapper.ToModel(appointmentDTO);
            _physicianScheduleService.Schedule(2, appointment);
            return Ok();
        }

        //    [HttpGet("{id}")]
        //    public ActionResult GetById(int id)
        //    {
        //        var appointment = _appointmentService.GetById(id);
        //        if (appointment == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(_appointmentMapper.ToDTO(appointment));
        //    }

        //    [HttpGet("doctorAppointments/{doctorId}")]
        //    public ActionResult GetDoctorAppointments(int doctorId)
        //    {
        //        return Ok(_appointmentMapper.ToDTO(_appointmentService.GetDoctorAppointments(doctorId)));
        //    }


        //    // DELETE api/appointments/2
        //    [HttpDelete("{id}")]
        //    public ActionResult Delete(int id)
        //    {
        //        var appointment = _appointmentService.GetById(id);
        //        if (appointment == null)
        //        {
        //            return NotFound();
        //        }

        //        _appointmentService.Delete(appointment);
        //        _notificationService.SendCancelNotification(appointment);
        //        return NoContent();
        //    }


        //    // PUT api/appintments/2
        //    [HttpPut("{id}")]
        //    public ActionResult Update(int id, AppointmentDTO appointmentDTO)
        //    {

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        if (id != appointmentDTO.AppointmentId)
        //        {
        //            return BadRequest();
        //        }

        //        Appointment appointment = _appointmentMapper.ToModel(appointmentDTO);

        //        try
        //        {
        //            _appointmentService.Update(appointment);
        //            _notificationService.SendUpdateNotification(appointment);
        //        }
        //        catch
        //        {
        //            return BadRequest();
        //        }



        //        return Ok(appointment);
        //    }

        //    [HttpGet("appointmentsInDataRange/{doctorId}")]
        //    public ActionResult GetAppointmentInVacationDataRange(int? doctorId, DateTime startDate, DateTime endDate)
        //    {
        //        return Ok(_appointmentMapper.ToDTO(_appointmentService.Get(doctorId, startDate, endDate)));
        //    }

        [HttpPost("bySpecialization")]
        public ActionResult GetAllBySpecialization(int specializationId)
        {
            return Ok(_doctorMapper.ToDTO(_doctorService.GetAllBySpecialization(specializationId).ToList()));
        }

        [HttpPost("getRecommendedAppointments")]
        public ActionResult GetRecommendedAppointments(RecommendedAppointmentsDTO recommendedAppointmentsDTO)
        {
            return Ok(_appointmentMapper.ToDTO(_physicianScheduleService.GetRecommendedAppointments(new DateRange(recommendedAppointmentsDTO.From,
                recommendedAppointmentsDTO.To), recommendedAppointmentsDTO.doctor, recommendedAppointmentsDTO.Priority)));
        }
        /*[HttpPost("create")]
        public ActionResult Create()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<WorkTime> workTimes = new List<WorkTime>();
            workTimes.Add(new WorkTime(new DateRange(new DateTime(2022, 12, 12), new DateTime(2022, 12, 23)),new DateTime(2022, 12, 23, 10, 0, 0), new DateTime(2022, 12, 23, 11, 0, 0)));
             PhysicianSchedule physicianSchedule = new PhysicianSchedule(2, 2, workTimes, new List<Appointment>());
            _physicianScheduleService.Create(physicianSchedule);
            return CreatedAtAction("GetById", new { id = physicianSchedule.Id }, physicianSchedule);

        }*/
    }
}
