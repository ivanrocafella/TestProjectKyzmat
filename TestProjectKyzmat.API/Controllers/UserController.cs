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
        const string INVAL_CRED = "Invalid credentials";
        const string SUCCESS_LOGOUT = "Successfully logged out";
        const string INVAL_TOKEN = "Invalid token";

        [HttpPost("login")]
        [EnableRateLimiting("fixed")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginUserRequest)
        {
            return await ValidateAndProceedAsync(async () => 
            { 
              Token? token = await userService.AuthUserAsync(loginUserRequest);
              if (token == null)
                  return StatusCode(500, new ErrorDTO(INVAL_CRED));
              else
                  return Ok(new { token_value = token.Value});  
            });
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var tokenValue = Request.Headers.Authorization.ToString().Replace("Bearer ", string.Empty);
            return await userService.LogoutUserAsync(tokenValue) ? Ok(new { message = SUCCESS_LOGOUT }) : Unauthorized(INVAL_TOKEN); 
        }
    }
}
