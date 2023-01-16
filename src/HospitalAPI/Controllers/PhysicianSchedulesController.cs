using System;
using System.Collections.Generic;
using System.Linq;
using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Security;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysicianSchedulesController : ControllerBase
    {
        private readonly IPhysicianScheduleService _service;
        private readonly IGenericMapper<PhysicianSchedule, PhysicianScheduleDTO> _mapper;
        private readonly IGenericMapper<Appointment, AppointmentDTO> _appointmentMapper;
        public PhysicianSchedulesController(IPhysicianScheduleService service, IGenericMapper<PhysicianSchedule, PhysicianScheduleDTO> mapper, IGenericMapper<Appointment, AppointmentDTO> appointmentMapper)
        {
            _service = service;
            _mapper = mapper;
            _appointmentMapper = appointmentMapper;
        }

        [HttpPost]
        public ActionResult Create(PhysicianScheduleDTO physicianScheduleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PhysicianSchedule physicianSchedule = _mapper.ToModel(physicianScheduleDTO);
            _service.Create(physicianSchedule);
            return CreatedAtAction("GetById", new { id = physicianSchedule.Id }, physicianSchedule);
        }

        [HttpPost("{doctorId}")]
        public ActionResult ScheduleAppointment(int doctorId, AppointmentDTO appointmentDTO)
        {
            if (_service.Schedule(doctorId, _appointmentMapper.ToModel(appointmentDTO)))
            {
                return Ok(doctorId);
            }
            else
                return Ok(0);
        }
        [HttpPost("schedule")]
        public ActionResult Schedule(AppointmentDTO appointmentDTO)
        {
            return Ok(_service.Schedule((int)appointmentDTO.DoctorId, _appointmentMapper.ToModel(appointmentDTO)));
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var physicianSchedyle = _service.GetById(id);
            if (physicianSchedyle == null)
            {
                return NotFound();
            }

            return Ok(_mapper.ToDTO(physicianSchedyle));
        }

        [HttpGet("doctor/{doctorId}")]
        public ActionResult GetPhysicianSchedule(int doctorId)
        {
            return Ok(_mapper.ToDTO(_service.Get(doctorId)));
        }

        [HttpGet("appointments/{doctorId}")]
        public ActionResult GetAppointments(int doctorId)
        {
            return Ok(_appointmentMapper.ToDTO(_service.GetAppointments(doctorId)));
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.ToDTO(_service.GetAll().ToList()));
        }

        [HttpGet("create")]
        public ActionResult Create()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<WorkTime> workTimes = new List<WorkTime>();
            workTimes.Add(new WorkTime(new DateRange(new DateTime(2023, 1, 10), new DateTime(2023, 12, 25)), new DateTime(2022, 11, 11, 7, 0, 0), new DateTime(2022, 11, 11, 15, 0, 0)));
            List<Appointment> appointments = new List<Appointment>();
            appointments.Add(new Appointment(new DateRange(new DateTime(2022, 12, 8, 7, 0, 0), new DateTime(2022, 12, 8, 7, 30, 0)), 1, null, 1, null, false));
            PhysicianSchedule physicianSchedule = new PhysicianSchedule(1, 1, null, workTimes, appointments, new List<Vacation>());
            _service.Create(physicianSchedule);
            return CreatedAtAction("GetById", new { id = physicianSchedule.Id }, physicianSchedule);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, PhysicianSchedule physicianSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != physicianSchedule.Id)
            {
                return BadRequest();
            }

            try
            {
                _service.Update(physicianSchedule);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(physicianSchedule);
        }


        [HttpPut("finish/{appointmentId}")]
        public ActionResult SetAppointmentToFinish(int appointmentId)
        {
            _service.SetAppointmentToFinish(appointmentId);
            return Ok(appointmentId);
        }
        
        [HttpGet("doctorWorkloadByDays")]
        public ActionResult GetDoctorWorkloadByDays(DoctorWorkloadDTO doctorWorkloadDTO)
        {
            return Ok(_service.GetDoctorWorkloadForDateRangeByDays(doctorWorkloadDTO.DoctorId, doctorWorkloadDTO.StartDate, doctorWorkloadDTO.EndDate));
        }

        [HttpGet("doctorWorkloadByMonths")]
        public ActionResult GetDoctorWorkloadByByMonths(DoctorWorkloadDTO doctorWorkloadDTO)
        {
            return Ok(_service.GetDoctorWorkloadForDateRangeByMonths(doctorWorkloadDTO.DoctorId, doctorWorkloadDTO.StartDate, doctorWorkloadDTO.EndDate));
        }

        [HttpPost("appointments/getAvailable")]
        public ActionResult GetAppointments(AppointmentDTO appointmentDTO)
        {
            List<String> times = new List<String>();
            foreach (AppointmentDTO appointment in _appointmentMapper.ToDTO(_service.GetAvailableAppointments((int)appointmentDTO.DoctorId, appointmentDTO.Date))) 
            {
                times.Add(appointment.Time);
            }
            return Ok(times);
        }
    }
}
