using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Threading.Tasks;
using IntegrationLibrary.Features.BloodBank.Service;
using IntegrationLibrary.Features.BloodBank.Model;
using IntegrationLibrary.Features.BloodBank.DTO;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public UsersController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost]
        public async Task<ActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _userService.Register(user);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var token = _userService.Login(userLogin, _config);

                if (token == null) 
                    return NotFound("User not found");

                return Ok(Content(token, "application/json"));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [Authorize]
        [HttpGet("data")]
        public ActionResult GetUserData()
        {
            if (HttpContext.User.Identity != null)
            {
                string email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                return Ok(JsonSerializer.Serialize(_userService.GetBy(email)));
            }
            return Unauthorized();
        }

        [Authorize]
        [HttpPatch("password")]
        public ActionResult ChangePassword([FromBody] ChangePasswordDTO dto)
        {
            if (HttpContext.User.Identity != null && dto != null)
            {
                string email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                
                _userService.ChangePassword(email, dto);
                
                return Ok();
            }
            return Unauthorized();
        }
    }
}
