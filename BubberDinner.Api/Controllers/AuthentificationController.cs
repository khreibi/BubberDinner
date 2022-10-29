using BubberDinner.Application.Services.Authentification;
using BubberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private IAuthentificationService _authentificationService;

        public AuthentificationController(IAuthentificationService authentificationService)
        {
            _authentificationService = authentificationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authentificationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            var authResponse = new AutentificationResponse(
                authResult.user.Id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.Token);


            return Ok(authResponse);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authentificationService.Login(request.Email, request.Password);

            var authResponse = new AutentificationResponse(
                authResult.user.Id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.Token
                );

            return Ok(authResponse);
        }

    }
}
