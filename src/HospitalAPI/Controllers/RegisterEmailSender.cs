﻿using MailKit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterEmailSender : ControllerBase
    {
        private readonly IEmailSender mailService;
        public RegisterEmailSender(IEmailSender mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailContent request)
        {
            try
            {
                await mailService.SendEmail(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
