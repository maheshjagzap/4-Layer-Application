using ApplicationLayer.Services;
using CoreLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var user = _userService.Login(loginDto.userName, loginDto.userPassword);

            if (user == null)
                return Unauthorized("Invalid username or password");

            return Ok(new { Message = "Login successful", User = user.userName });
        }
    }
}
