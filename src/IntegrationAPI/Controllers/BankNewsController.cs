using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.Features.BloodBankNews.Service;
using IntegrationLibrary.Features.BloodBankNews.Enums;

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

        [HttpGet("new")]
        public ActionResult GetNewNews()
        {
            return Ok(_bankNewsService.GetAllByState(NewsState.NEW));
        }

        [HttpGet("approved")]
        public ActionResult GetApprovedNews()
        {
            return Ok(_bankNewsService.GetAllByState(NewsState.APPROVED));
        }

        [HttpGet("declined")]
        public ActionResult GetDeclinedNews()
        {
            return Ok(_bankNewsService.GetAllByState(NewsState.DECLINED));
        }

        [HttpPatch("approve")]
        public ActionResult ApproveNews([FromBody] int id)
        {
            _bankNewsService.ApproveNews(id);
            return Ok();
        }

        [HttpPatch("decline")]
        public ActionResult DeclineNews([FromBody] int id)
        {
            _bankNewsService.DeclineNews(id);
            return Ok();
        }
    }
}
