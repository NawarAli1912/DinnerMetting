using DinnerMetting.Application.Authentication.Command.Register;
using DinnerMetting.Application.Authentication.Queries;
using DinnerMetting.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinnerMetting.Api.Controllers;

[ApiController]
[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<RegisterCommand>(request));


        return result.Match(
            value => Ok(_mapper.Map<AuthenticationResponse>(value)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<LoginQuery>(request));

        return result.Match(
            value => Ok(_mapper.Map<AuthenticationResponse>(value)),
            errors => Problem(errors));
    }
}
