using Microsoft.AspNetCore.Mvc;
using QuoteManager.Application.DTOs;
using QuoteManager.Application.Interfaces;

namespace QuoteManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            var result = await authService.RegisterAsync(dto);
            return result is null ? BadRequest("Email already in use.") : Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
        {
            var result = await authService.LoginAsync(dto);
            return result is null ? Unauthorized("Invalid credentials.") : Ok(result);
        }
    }
}
