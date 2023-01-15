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
    public class BloodUsageEvidencyController : ControllerBase
    {
        private readonly IBloodUsageEvidencyService _bloodUsageEvidencyService;
        private readonly IBloodService _bloodService;
        private readonly IGenericMapper<BloodUsageEvidency, BloodUsageEvidencyDTO> _bloodUsageEvidencyMapper;

        public BloodUsageEvidencyController(IBloodUsageEvidencyService bloodUsageEvidencyService, IBloodService bloodService, IGenericMapper<BloodUsageEvidency, BloodUsageEvidencyDTO> bloodUsageEvidencyMapper)
        {
            _bloodUsageEvidencyService = bloodUsageEvidencyService;
            _bloodService = bloodService;
            _bloodUsageEvidencyMapper = bloodUsageEvidencyMapper;
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_bloodUsageEvidencyMapper.ToDTO(_bloodUsageEvidencyService.GetAll().ToList()));
        }

        [HttpPost]
        public ActionResult Create(BloodUsageEvidencyDTO bloodUsageEvidencyDTO)
        { 
             // zakucano trenutno
            bloodUsageEvidencyDTO.DoctorId = 1;
          
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BloodUsageEvidency bloodUsageEvidency = _bloodUsageEvidencyMapper.ToModel(bloodUsageEvidencyDTO);
            Boolean isEnoughBlood;
            try
            {
               isEnoughBlood = _bloodService.ChangeQuantityy(bloodUsageEvidency);
                
            }
            catch
            {
                return BadRequest();
            }
            if (isEnoughBlood)
            {
                _bloodUsageEvidencyService.Create(bloodUsageEvidency);
            }

            return CreatedAtAction("GetById", new { id = bloodUsageEvidency.BloodUsageEvidencyId }, bloodUsageEvidency);

        }



        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var bloodUsageEvidency = _bloodUsageEvidencyService.GetById(id);
            if (bloodUsageEvidency == null)
            {
                return NotFound();
            }

            return Ok(_bloodUsageEvidencyMapper.ToDTO(bloodUsageEvidency));
        }
    }
}
