using IntegrationLibrary.Features.EquipmentTenders.Application;
using IntegrationLibrary.Features.EquipmentTenders.Application.Abstract;
using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.EquipmentTenders.DTO;
using IntegrationLibrary.Features.MonthlyBloodSubscription.DTO;
using IntegrationLibrary.Features.MonthlyBloodSubscription.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodSubscriptionController : ControllerBase
    {
        private readonly IBloodSubscriptionService _bloodSubscriptionService;
        public BloodSubscriptionController(IBloodSubscriptionService subscriptionService)
        {
            _bloodSubscriptionService = subscriptionService;
        }

        [HttpGet("subscribed")]
        public IActionResult GetAllSubscribed()
        {
            return Ok(_bloodSubscriptionService.GetAllSubscribed());
        }

        [HttpGet("unsubscribed")]
        public IActionResult GetAllUnsubscribed()
        {
            return Ok(_bloodSubscriptionService.GetAllUnsubscribed());
        }

        [HttpPost("subscribe")]
        public IActionResult Subscribe([FromBody] CreateSubscriptionDTO dto)
        {
            _bloodSubscriptionService.Subscribe(dto);
            return Ok();
        }

        [HttpDelete("unsubscribe/{bloodBankId:int}")]
        public IActionResult Unsubscribe(int bloodBankId)
        {
            _bloodSubscriptionService.Unsubscribe(bloodBankId);
            return Ok();
        }

        [HttpPost("receive-blood")]
        public IActionResult ReceiveBlood([FromBody] ReceivedBloodDTO dto)
        {
            _bloodSubscriptionService.ReceiveBlood(dto);
            return Ok();
        }
    }
}
