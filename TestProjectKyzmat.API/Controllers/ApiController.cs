using Microsoft.AspNetCore.Mvc;

namespace TestProjectKyzmat.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ApiController : ControllerBase
    {
        protected async Task<IActionResult> ValidateAndProceedAsync(Func<Task<IActionResult>> action)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = "Invalid model state",
                    details = ModelState
                        .Where(m => m.Value?.Errors.Any() == true)
                        .ToDictionary(
                            m => m.Key,
                            m => m.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                        )
                });
            }
            return await action();
        }
    }
}
