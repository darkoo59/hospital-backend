using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IGenericMapper<Doctor, DoctorDTO> _doctorMapper;

        public DoctorController(IDoctorService doctorService, IGenericMapper<Doctor, DoctorDTO> doctorMapper)
        {
            _doctorService = doctorService;
            _doctorMapper = doctorMapper;
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            return Ok(_doctorMapper.ToDTO(_doctorService.GetById(id)));
        }



    }
}
