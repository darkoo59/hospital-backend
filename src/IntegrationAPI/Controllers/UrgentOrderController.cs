using IntegrationAPI.Authorization;
using IntegrationLibrary.Features.Blood.Enums;
using IntegrationLibrary.Features.UrgentBloodOrder.DTO;
using IntegrationLibrary.Features.UrgentBloodOrder.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrgentOrderController : ControllerBase
    {
        private readonly IUrgentBloodOrderService _service;

        public UrgentOrderController(IUrgentBloodOrderService service)
        {
            _service = service;
        }

        [HttpPatch]
        public ActionResult InvokeUrgentOrder([FromBody] UrgentOrderDTO dto)
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();

            UrgentResponse result = _service.InvokeUrgentOrder(dto.BloodType, dto.Quantity, dto.Server);
            
            Console.WriteLine("Type: " + dto.BloodType + " Quantity: " + dto.Quantity + " server: " + dto.Server);
            
            Console.WriteLine("Response: " + result.HasEnough);

            return Ok(result.HasEnough);
        }

        [HttpPost]
        public ActionResult GenerateUrgentOrderReport([FromBody] UrgentOrderReportDTO dto)
        {
            //if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();

            _service.CreateUrgentOrderReport(dto.DateFrom, dto.DateTo);

            return Ok();
        }
    }
}
