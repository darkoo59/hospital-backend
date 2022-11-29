using IntegrationLibrary.Features.EquipmentTenders.Application.Abstract;
using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.EquipmentTenders.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [HttpPost]
        public IActionResult Create([FromBody] CreateEquipmentTenderDTO dto)
        {
            _equipmentTenderService.Create(dto);
            return Ok();
        }
    }
}
