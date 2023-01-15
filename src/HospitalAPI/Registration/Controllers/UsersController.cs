using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.SharedModel;
using HospitalLibrary.Security;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using System;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Diagnostics;
using HospitalAPI.Registration.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace HospitalAPI.Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericMapper<User, UserDTO> _userMapper;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, IGenericMapper<User, UserDTO> userMapper)
        {
            _userMapper = userMapper;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDTO userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var token = _userService.Login(userLogin.Username, userLogin.Password);

                if (token == null)
                    return NotFound("User not found");

                return Ok(Content(token.AccessToken, "application/json"));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpGet("data")]
        public ActionResult GetUserData()
        {
            if (HttpContext.User.Identity != null)
            {
                var userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == "id").Value);
                var role = HttpContext.User.Claims.First(c => c.Type.Equals(ClaimTypes.Role)).Value;
                return Ok(JsonSerializer.Serialize(_userService.GetById(userId)));
            }
            return Unauthorized();
        }
        
        [HttpGet("authorization/manager")]
        public ActionResult GetManagerAuthorization()
        {
            if (HttpContext.User.Identity == null) return Unauthorized();
            try
            {
                var userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == "id").Value);
                var role = HttpContext.User.Claims.First(c => c.Type.Equals(ClaimTypes.Role)).Value;
                if (role == "manager")
                {
                    return Ok(JsonSerializer.Serialize(_userService.GetById(userId)));
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
