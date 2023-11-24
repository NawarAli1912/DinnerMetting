using DinnerMetting.Application.Authentication;
using DinnerMetting.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace DinnerMetting.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        return result.Match(
            value => Ok(value),
            error => Problem(statusCode: StatusCodes.Status409Conflict));
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _authenticationService.Login(request.Email, request.Password);

        return result.Match(
            value => Ok(value),
            error => Problem(statusCode: StatusCodes.Status409Conflict));
    }
}
