using System;
using IntegrationLibrary.Features.ReportConfigurations.Model;
using IntegrationLibrary.Features.ReportConfigurations.Service;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(_configurationService.GetReportConfigurations());
        }

        [HttpPost]
        public ActionResult CreateOrUpdateReportConfiguration([FromBody] ReportConfiguration configuration)
        {
            Console.WriteLine("uslo");
            _configurationService.CreateOrUpdateReportConfiguration(configuration);
            return Ok();
        }
    }
}