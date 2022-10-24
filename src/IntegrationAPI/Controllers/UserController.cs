using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _userService.Register(user);
            }catch(User.DuplicateEMailException e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }
    }
}
