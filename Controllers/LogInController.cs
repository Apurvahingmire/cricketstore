
using CricketStore.BLL.DTOs.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CricketStore.BLL.Services;


namespace CricketStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class LogInController : ControllerBase
    {
        private readonly ILogInService LogInService;
        public LogInController(ILogInService LogInService)
        {
            this.LogInService = LogInService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(LogInRequestDTO LogInRequestDTO)
        {
            var result = await LogInService.IsValidUser(LogInRequestDTO);
            if (result is not null)
            {
                return Ok(result);
            }
            return Unauthorized(new { message = "Invalid Login!" });
        }
    }


}
