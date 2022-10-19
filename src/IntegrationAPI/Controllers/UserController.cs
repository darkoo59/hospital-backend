using IntegrationLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult Register()
        {
            return Ok("register");
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }
    }
}
