using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.Features.BloodBankNews.Service;
using IntegrationLibrary.Features.BloodBankNews.Enums;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IntegrationLibrary.Settings;

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
                if (IsAuthorized(AuthenticationHeaderValue.Parse(Request.Headers["Authorization"])))
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
                if (IsAuthorized(AuthenticationHeaderValue.Parse(Request.Headers["Authorization"])))
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
                if (IsAuthorized(AuthenticationHeaderValue.Parse(Request.Headers["Authorization"])))
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
                if (IsAuthorized(AuthenticationHeaderValue.Parse(Request.Headers["Authorization"])))
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
                if (IsAuthorized(AuthenticationHeaderValue.Parse(Request.Headers["Authorization"])))
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
                if (IsAuthorized(AuthenticationHeaderValue.Parse(Request.Headers["Authorization"])))
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


        private static async Task<bool> Authorize(string token)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var url = AppSettings.HospitalApiUrl + "/api/users/authorization/manager";

            var response = await httpClient.GetAsync(url);
            return response.StatusCode == HttpStatusCode.OK;
        }
        

        private bool IsAuthorized(AuthenticationHeaderValue header)
        {
            var credentials = header.Parameter;
            return Authorize(credentials).Result;
        }
    }
}
