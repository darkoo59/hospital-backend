using System;
using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.Features.BloodBankNews.Service;
using IntegrationLibrary.Features.BloodBankNews.Enums;
using System.Net.Http.Headers;
using IntegrationAPI.Authorization;

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
            try
            {
                if (AuthorizationUtil.IsAuthorized(AuthenticationHeaderValue.Parse(Request.Headers["Authorization"])))
                {
                    return Ok(_bankNewsService.GetAll());
                }
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            return Unauthorized();
        }

        [HttpGet("new")]
        public ActionResult GetNewNews()
        {
            try
            {
                if (AuthorizationUtil.IsAuthorized(AuthenticationHeaderValue.Parse(Request.Headers["Authorization"])))
                {
                    return Ok(_bankNewsService.GetAllByState(NewsState.NEW));
                }
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            return Unauthorized();
        }

        [HttpGet("approved")]
        public ActionResult GetApprovedNews()
        {
            try
            {
                if (AuthorizationUtil.IsAuthorized(AuthenticationHeaderValue.Parse(Request.Headers["Authorization"])))
                {
                    return Ok(_bankNewsService.GetAllByState(NewsState.APPROVED));
                }
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            return Unauthorized();
        }

        [HttpGet("declined")]
        public ActionResult GetDeclinedNews()
        {
            try
            {
                if (AuthorizationUtil.IsAuthorized(AuthenticationHeaderValue.Parse(Request.Headers["Authorization"])))
                {
                    return Ok(_bankNewsService.GetAllByState(NewsState.DECLINED));
                }
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            return Unauthorized();
        }

        [HttpPatch("approve")]
        public ActionResult ApproveNews([FromBody] int id)
        {
            try
            {
                if (AuthorizationUtil.IsAuthorized(AuthenticationHeaderValue.Parse(Request.Headers["Authorization"])))
                {
                    _bankNewsService.ApproveNews(id);
                    return Ok();
                }
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            return Unauthorized();
        }

        [HttpPatch("decline")]
        public ActionResult DeclineNews([FromBody] int id)
        {
            try
            {
                if (AuthorizationUtil.IsAuthorized(AuthenticationHeaderValue.Parse(Request.Headers["Authorization"])))
                {
                    _bankNewsService.DeclineNews(id);
                    return Ok();
                }
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            return Unauthorized();
        }
    }
}
