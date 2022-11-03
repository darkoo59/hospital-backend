using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.Features.BloodBankNews.Service;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankNewsController : ControllerBase
    {
        private readonly IBankNewsService _bankNewsService;

        public BankNewsController(IBankNewsService bankNewsService)
        {
            _bankNewsService = bankNewsService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_bankNewsService.GetAll());
        }
    }
}
