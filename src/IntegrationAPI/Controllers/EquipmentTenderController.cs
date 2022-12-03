using IntegrationLibrary.Features.EquipmentTenders.Application.Abstract;
using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.EquipmentTenders.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentTenderController : ControllerBase
    {
        private readonly IEquipmentTenderService _equipmentTenderService;
        public EquipmentTenderController(IEquipmentTenderService equipmentTenderService)
        {
            _equipmentTenderService = equipmentTenderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(EquipmentTenderDTO.ToDTOList(_equipmentTenderService.GetAll()));
        }

        [HttpGet("bloodbank")]
        public IActionResult GetAllByBloodbank()
        {
            if (HttpContext.User.Identity != null)
            {
                string email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                return Ok(EquipmentTenderDTO.ToDTOList(_equipmentTenderService.GetAllByUser(email)));
            }
            return Unauthorized();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EquipmentTender et = _equipmentTenderService.GetById(id);
            if (et == null) throw new Exception("Tender with the given ID has not been found.");
            return Ok(new EquipmentTenderDTO(et));
        }

        [HttpGet("bloodbank/{id}")]
        public IActionResult GetByIDAndBloodBank(int id)
        {
            if (HttpContext.User.Identity != null)
            {
                string email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                return Ok(new EquipmentTenderDTO(_equipmentTenderService.GetByIdAndUser(id, email)));
            }
            return Unauthorized();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateEquipmentTenderDTO dto)
        {
            _equipmentTenderService.Create(dto);
            return Ok();
        }

        [HttpPost("application")]
        public IActionResult CreateApplication([FromBody] CreateTenderApplicationDTO dto)
        {
            if (HttpContext.User.Identity != null)
            {
                string email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                _equipmentTenderService.CreateApplication(email, dto);
                return Ok();
            }
            return Unauthorized();
        }

        [HttpGet("application")]
        public IActionResult GetApplicationsByBloodBank()
        {
            if (HttpContext.User.Identity != null)
            {
                string email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                
                return Ok(UserTenderApplicationDTO.ToDTOList(_equipmentTenderService.GetApplicationsByUser(email)));
            }
            return Unauthorized();
        }

        [HttpGet("application/{id}")]
        public IActionResult GetApplicationById(int id)
        {
            TenderApplication ta = _equipmentTenderService.GetApplicationById(id);
            if (ta == null) throw new Exception("Tender application with the given ID has not been found.");
            return Ok(new UserTenderApplicationDTO(ta));
        }

        [HttpDelete("application/{id}")]
        public IActionResult DeleteApplicationByIdAndBloodBank(int id)
        {
            if (HttpContext.User.Identity != null)
            {
                string email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                _equipmentTenderService.DeleteApplicationByIdAndUser(id, email);
                return Ok();
            }
            return Unauthorized();
        }
    }
}
