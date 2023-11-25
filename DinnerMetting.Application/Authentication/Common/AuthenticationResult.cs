namespace DinnerMetting.Application.Authentication.Common;

public record AuthenticationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);
