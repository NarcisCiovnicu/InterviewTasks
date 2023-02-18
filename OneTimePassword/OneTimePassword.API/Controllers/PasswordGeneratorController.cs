using Microsoft.AspNetCore.Mvc;
using OneTimePassword.BusinessLogic.Services;
using OneTimePassword.Domain.Models;

namespace OneTimePassword.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PasswordGeneratorController : ControllerBase
    {
        private readonly IPasswordGeneratorService _passwordGeneratorService;

        public PasswordGeneratorController(IPasswordGeneratorService passwordGeneratorService)
        {
            _passwordGeneratorService = passwordGeneratorService;
        }

        [HttpPost]
        public IActionResult GetCurrentPassword(UserOtpRequest userOtpRequest)
        {
            var generatedPassword = _passwordGeneratorService.GetGeneratedPassword(userOtpRequest);
            return Ok(generatedPassword);
        }
    }
}
