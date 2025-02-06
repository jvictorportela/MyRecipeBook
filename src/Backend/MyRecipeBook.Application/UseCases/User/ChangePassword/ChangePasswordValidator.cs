﻿using FluentValidation;
using MyRecipeBook.Communication.Requests;

namespace MyRecipeBook.Application.UseCases.User.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<RequestChangePasswordJson>
{
    public ChangePasswordValidator()
    {
        RuleFor(x => x.NewPassword);
    }
}