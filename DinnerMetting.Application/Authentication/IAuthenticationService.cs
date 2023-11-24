using DinnerMetting.Domain.SharedKernel;

namespace DinnerMetting.Application.Authentication;

public interface IAuthenticationService
{
    Result<AuthenticationResult> Login(string email, string password);

    Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);

}
