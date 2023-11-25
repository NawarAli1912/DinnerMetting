using DinnerMetting.Application.Authentication.Common;
using DinnerMetting.Application.Common.JWT;
using DinnerMetting.Application.Persistence;
using DinnerMetting.Domain.Entities;
using DinnerMetting.Domain.Errors;
using DinnerMetting.Domain.SharedKernel;
using MediatR;

namespace DinnerMetting.Application.Authentication.Command.Register;

internal class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, Result<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<Result<AuthenticationResult>> Handle(
    RegisterCommand request,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Check if user already exists
        if (_userRepository.GetUserByEmail(request.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // Creatte user (generate unique ID)
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };

        // Create JWT token
        var token = _jwtTokenGenerator.Generate(user.Id.ToString(), request.FirstName, request.LastName);

        _userRepository.Add(user);

        return new AuthenticationResult(
            user.Id,
            request.FirstName,
            request.LastName,
            request.Email,
            token);
    }
}
