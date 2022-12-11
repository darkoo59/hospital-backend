using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
    //    private readonly IAppointmentService _appointmentService;
    //    private readonly IGenericMapper<Appointment, AppointmentDTO> _appointmentMapper;
    //    private readonly INotificationService _notificationService;


    //    public AppointmentsController(IAppointmentService appointmentService, IGenericMapper<Appointment, AppointmentDTO> appointmentMapper, INotificationService notificationService)
    //    {
    //        _appointmentService = appointmentService;
    //        _appointmentMapper = appointmentMapper;
    //        _notificationService = notificationService;
    //    }

    //    [HttpGet]
    //    public ActionResult GetAll()
    //    {
    //        return Ok(_appointmentMapper.ToDTO(_appointmentService.GetAll().ToList()));
    //    }

    //    [HttpPost]
    //    public ActionResult Create(AppointmentDTO appointmentDTO)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        // zakucano trenutno
    //        appointmentDTO.DoctorId = 1;
    //        Appointment appointment = _appointmentMapper.ToModel(appointmentDTO);
    //        _appointmentService.Create(appointment);
    //        return CreatedAtAction("GetById", new { id = appointment.AppointmentId }, appointment);
    //    }

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


    }
}
