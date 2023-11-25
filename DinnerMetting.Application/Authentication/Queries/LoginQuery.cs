using DinnerMetting.Application.Authentication.Common;
using DinnerMetting.Domain.SharedKernel;
using MediatR;

namespace DinnerMetting.Application.Authentication.Queries;

public record LoginQuery(
    string Email,
    string Passwrod) : IRequest<Result<AuthenticationResult>>;
