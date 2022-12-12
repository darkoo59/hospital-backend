using IntegrationAPI.Authorization;
using IntegrationLibrary.Features.ManagerNotification.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IManagerNotificationService _notificationService;

        public NotificationController(IManagerNotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            return Ok(_notificationService.GetAll());
        }

        [HttpDelete("delete/{id:int}")]
        public IActionResult Unsubscribe(int id)
        {
            if (!AuthorizationUtil.IsAuthorized(Request)) return Unauthorized();
            _notificationService.Remove(id);
            return Ok();
        }
    }
}
