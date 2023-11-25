using FluentValidation;

namespace DinnerMetting.Application.Authentication.Command.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email).EmailAddress();

        RuleFor(x => x.Password).Length(8, 128);

        RuleFor(x => x.FirstName).NotEmpty();

        RuleFor(x => x.LastName).NotEmpty();
    }
}
