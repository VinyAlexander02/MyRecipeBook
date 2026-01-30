

using FluentValidation;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Exeptions;

namespace MyRecipeBook.Application.Usecases.User.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesExceptions.NAME_EMPTY);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessagesExceptions.EMAIL_EMPTY);
        RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagesExceptions.EMAIL_INVALID);
        RuleFor(user => user.Password).NotEmpty().MinimumLength(6).WithMessage(ResourceMessagesExceptions.PASSWORD_EMPTy);
    }
}

