using IntegrationAPI.Authorization;
using IntegrationLibrary.Features.MonthlyBloodSubscription.DTO;
using IntegrationLibrary.Features.MonthlyBloodSubscription.Service;
using Microsoft.AspNetCore.Mvc;

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
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            return Ok(_bloodSubscriptionService.GetAllSubscribed());
        }

        [HttpGet("unsubscribed")]
        public IActionResult GetAllUnsubscribed()
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            return Ok(_bloodSubscriptionService.GetAllUnsubscribed());
        }

        [HttpPost("subscribe")]
        public IActionResult Subscribe([FromBody] CreateSubscriptionDTO dto)
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            _bloodSubscriptionService.Subscribe(dto);
            return Ok();
        }

        [HttpDelete("unsubscribe/{bloodBankId:int}")]
        public IActionResult Unsubscribe(int bloodBankId)
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            _bloodSubscriptionService.Unsubscribe(bloodBankId);
            return Ok();
        }

        [HttpPost("receive-blood")]
        public IActionResult ReceiveBlood([FromBody] ReceivedBloodDTO dto)
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            _bloodSubscriptionService.ReceiveBlood(dto);
            return Ok();
        }
    }
}
