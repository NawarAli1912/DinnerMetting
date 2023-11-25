using DinnerMetting.Application.Authentication.Common;
using DinnerMetting.Domain.SharedKernel;
using MediatR;

namespace DinnerMetting.Application.Authentication.Command.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<Result<AuthenticationResult>>;
