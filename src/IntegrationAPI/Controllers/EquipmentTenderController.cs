using IntegrationLibrary.Features.EquipmentTenders.Application.Abstract;
using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.EquipmentTenders.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            return Ok(EquipmentTenderDTO.ToDTOList(_equipmentTenderService.GetAll() as List<EquipmentTender>));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EquipmentTender et = _equipmentTenderService.GetById(id);
            if (et == null) throw new Exception("Tender with the given ID has not been found.");
            return Ok(new EquipmentTenderDTO(et));
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
    }
}
