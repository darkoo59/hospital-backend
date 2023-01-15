using IntegrationAPI.Authorization;
using IntegrationLibrary.Core.Utility;
using IntegrationLibrary.Features.BloodBankNews.Enums;
using IntegrationLibrary.Features.EquipmentTenders.Application;
using IntegrationLibrary.Features.EquipmentTenders.Application.Abstract;
using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.EquipmentTenders.DTO;
using IntegrationLibrary.Features.EquipmentTenders.DTO.CreateDTO;
using IntegrationLibrary.Features.EquipmentTenders.DTO.UserDTO;
using IntegrationLibrary.Features.UrgentBloodOrder.DTO;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using System;
using System.IO;
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
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
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
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
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

        [HttpGet("application/tender/{id}")]
        public IActionResult GetAllApplicationsByTenderId(int id)
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            EquipmentTender et = _equipmentTenderService.GetTenderWithApplicationsById(id);
            if (et == null) throw new Exception("Tender with the given ID has not been found.");
            return Ok(new TenderWithApplicationsDTO(et));
        }

        [HttpGet("application/{id}")]
        public IActionResult GetApplicationById(int id)
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
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

        [HttpPatch("winner")]
        public IActionResult SetWinner([FromBody] int id)
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            _equipmentTenderService.SetWinner(id);
            return Ok();
        }

        [HttpPatch("winner/confirm")]
        public IActionResult ConfirmWinner([FromBody] int id)
        {
            if (HttpContext.User.Identity != null)
            {
                string email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                _equipmentTenderService.ConfirmWinner(id, email);
                return Ok();
            }
            return Unauthorized();

        }

        [HttpPatch("winner/decline")]
        public IActionResult DeclineWinner([FromBody] int id)
        {
            if (HttpContext.User.Identity != null)
            {
                string email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                _equipmentTenderService.DeclineWinner(id, email);
                return Ok();
            }
            return Unauthorized();
        }

        [HttpPost("report")]
        public IActionResult GenerateAndUploadPdf([FromBody] UrgentOrderReportDTO dto)
        {
            if (HttpContext.User.Identity != null)
            {
                string filepath = _equipmentTenderService.GenerateAndUploadPdf(new DateRange(dto.DateFrom, dto.DateTo));

                var file = System.IO.File.OpenRead(filepath);

                return File(file, "application/pdf");

            }
            return Ok();
        }
    }
}
