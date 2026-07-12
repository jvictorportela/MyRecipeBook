using FluentValidation;
using MyRecipeBook.Communication.Requests;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserAccountValidator : AbstractValidator<RequestRegisterUserAccountJson>
{
    public RegisterUserAccountValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("The name cannot be empty.");
        RuleFor(user => user.Email).NotEmpty().WithMessage("The email cannot be empty.");
        RuleFor(user => user.Password).NotEmpty().WithMessage("The password cannot be empty.");
        When(user => string.IsNullOrWhiteSpace(user.Email) is false, () =>
        {
            RuleFor(user => user.Email).EmailAddress().WithMessage("The email is not valid.");
        });
    }
}
