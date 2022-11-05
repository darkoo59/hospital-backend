using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.Features.BloodBankNews.Service;
using IntegrationLibrary.Features.BloodBankNews.Model;

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

        [HttpGet("unchecked")]
        public ActionResult GetUncheckedNews()
        {
            return Ok(_bankNewsService.GetAllByState(NewsStateEnum.UNCHECKED));
        }

        [HttpGet("approved")]
        public ActionResult GetApprovedNews()
        {
            return Ok(_bankNewsService.GetAllByState(NewsStateEnum.APPROVED));
        }

        [HttpGet("disapproved")]
        public ActionResult GetDisapprovedNews()
        {
            return Ok(_bankNewsService.GetAllByState(NewsStateEnum.DISAPPROVED));
        }

        [HttpPatch("approve")]
        public ActionResult ApproveNews([FromQuery(Name = "id")] int id)
        {
            _bankNewsService.ApproveNews(id);
            return Ok();
        }

        [HttpPatch("disapprove")]
        public ActionResult DisapproveNews([FromQuery(Name = "id")] int id)
        {
            _bankNewsService.DisapproveNews(id);
            return Ok();
        }
    }
}
