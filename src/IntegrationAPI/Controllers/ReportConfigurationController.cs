using System;
using IntegrationAPI.Authorization;
using System.Net.Http.Headers;
using IntegrationLibrary.Features.ReportConfigurations.Model;
using IntegrationLibrary.Features.ReportConfigurations.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportConfigurationController : ControllerBase
    {
        private readonly IReportConfigurationService _configurationService;

        public ReportConfigurationController(IReportConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }
        
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                if (AuthorizationUtil.IsAuthorized(Request))
                {
                    return Ok(_configurationService.GetReportConfigurations());
                }
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            return Unauthorized();
        }

        [HttpPost]
        public ActionResult CreateOrUpdateReportConfiguration([FromBody] ReportConfiguration configuration)
        {
            try
            {
                if (AuthorizationUtil.IsAuthorized(Request))
                {
                    _configurationService.CreateOrUpdateReportConfiguration(configuration);
                    return Ok();
                }
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            return Unauthorized();
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                if (AuthorizationUtil.IsAuthorized(Request))
                {
                    return Ok(_configurationService.GetConfigurationById(id));
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