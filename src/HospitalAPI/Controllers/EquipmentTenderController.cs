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
    public class EquipmentTenderController : ControllerBase
    {

        private readonly IEquipmentTenderService _service;

        public EquipmentTenderController(IEquipmentTenderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var equipmentTenders = await _service.GettAll();
            return Ok(equipmentTenders);
        }


    }
}
