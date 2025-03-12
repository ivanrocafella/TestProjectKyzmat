using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using TestProjectKyzmat.BAL.DTOs.User;
using TestProjectKyzmat.BAL.Services.Interfaces;
using TestProjectKyzmat.Core.Entities;

namespace TestProjectKyzmat.API.Controllers
{
    public class UserController(IUserService userService) : ApiController
    {
        private const string invalCred = "Invalid credentials";
        private const string successLoggedOut = "Successfully logged out";
        private const string invalToken = "Invalid token";

        [HttpPost("login")]
        [EnableRateLimiting("fixed")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestDTO loginUserRequest)
        {
            Token? token = await userService.AuthUserAsync(loginUserRequest);
            if (token == null)
                return StatusCode(500, new ErrorDTO(invalCred));
            else
                return Ok(token);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var tokenValue = Request.Headers.Authorization.ToString().Replace("Bearer ", string.Empty);
            return await userService.LogoutUserAsync(tokenValue) ? Ok(new { message = successLoggedOut }) : Unauthorized(invalToken); 
        }
    }
}
