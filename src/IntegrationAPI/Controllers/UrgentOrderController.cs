using IntegrationLibrary.Features.UrgentBloodOrder.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrgentOrderController : ControllerBase
    {
        private readonly IUrgentOrderService _service;

        public UrgentOrderController(IUrgentOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult InvokeUrgentOrder()
        {
            StudentResponse result = _service.InvokeUrgentOrder();

            return Ok(result.ToString());
        }
    }
}
