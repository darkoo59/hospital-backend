using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        private readonly IGenericMapper<Medicine, MedicineDTO> _medicineMapper;

        public MedicinesController(IMedicineService medicineService, IGenericMapper<Medicine, MedicineDTO> medicineMapper)
        {
            _medicineService = medicineService;
            _medicineMapper = medicineMapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_medicineMapper.ToDTO(_medicineService.GetAll().ToList()));
        }
    }
}
