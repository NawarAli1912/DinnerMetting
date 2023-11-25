using DinnerMetting.Application.Authentication.Common;
using DinnerMetting.Application.Common.JWT;
using DinnerMetting.Application.Persistence;
using DinnerMetting.Domain.Entities;
using DinnerMetting.Domain.Errors;
using DinnerMetting.Domain.SharedKernel;
using MediatR;

namespace DinnerMetting.Application.Authentication.Queries;

internal class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<Result<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Check the user exists
        if (_userRepository.GetUserByEmail(request.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        // Validate the password 
        if (user.Password != request.Passwrod)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Create the JWT token
        var token = _jwtTokenGenerator.Generate(user.Id.ToString(), user.FirstName, user.LastName);

        return new AuthenticationResult(
            user.Id,
            user.FirstName,
            user.LastName,
            request.Email,
            token);

    }
}
