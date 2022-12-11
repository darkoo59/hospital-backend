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
    public class BloodsController : ControllerBase
    {
        private readonly IBloodService _bloodService;
        private readonly IGenericMapper<Blood, BloodDTO> _bloodMapper;

        public BloodsController(IBloodService bloodService, IGenericMapper<Blood, BloodDTO> bloodMapper)
        {
            _bloodService = bloodService;
            _bloodMapper = bloodMapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_bloodMapper.ToDTO(_bloodService.GetAll().ToList()));
        }

        [HttpPatch("add")]
        public ActionResult AddBloodAfterUrgentRequest([FromBody] UrgentBloodRequestDTO dto)
        {
            _bloodService.AddBloodAfterUrgentRequest(dto.BloodType, dto.Quantity);
            return Ok();
        }
        
        [HttpPost("receive-blood")]
        public ActionResult ReceiveNewBlood(BloodDTO dto)
        {
            _bloodService.ReceiveNewBlood(_bloodMapper.ToModel(dto));
            return Ok();
        }
        
        [HttpPatch("tender")]
        public IActionResult PatchAfterTender([FromBody]ICollection<TenderBloodDTO> dtos)
        {
            
            _bloodService.UpdateAfterTender(TenderBloodDTO.FromDTOList(dtos));
            return Ok();
        }
    }
}
