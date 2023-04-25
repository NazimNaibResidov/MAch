﻿using Common.ViewModel;
using FluentValidation;

namespace Core.Validators.User
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("{PropertyName} not valid");
            RuleFor(x => x.Password)
                .NotNull()
                .MinimumLength(6)
                .WithMessage("{PropertyName} should at least be {MinLenght} character");
        }
    }
}
