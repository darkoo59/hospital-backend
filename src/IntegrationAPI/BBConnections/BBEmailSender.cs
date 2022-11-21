using IntegrationLibrary.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using IntegrationLibrary.Features.BloodBank;

namespace IntegrationAPI.BBConnections
{
    [Route("api/[controller]")]
    [ApiController]
    public class BBEmailSender : ControllerBase
    {
        private readonly IBloodBankService mailService;
        public BBEmailSender(IBloodBankService mailService)
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
            catch (Exception)
            {
                throw;
            }

        }
    }
}
