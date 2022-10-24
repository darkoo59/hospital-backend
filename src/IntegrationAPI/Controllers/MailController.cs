using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using IntegrationLibrary.Core.Service;
using IntegrationLibrary.Core.Model;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailContent mailContent)
        {
            try
            {
                await mailService.SendEmail(mailContent);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
