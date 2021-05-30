using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().Length(2, 30)
                .WithMessage("{PropertyName} length must be between 2 and 30 characters!");
            RuleFor(u => u.LastName).NotEmpty().Length(2, 30)
                .WithMessage("{PropertyName} length must be between 2 and 30 characters!");
            RuleFor(u => u.Email).NotEmpty().WithMessage("{PropertyName} field must be filled!")
                .EmailAddress().WithMessage("{PropertyName} is in invalid format!")
                .Length(10, 50).WithMessage("{PropertyName} length must be between 10 and 50 characters!");
            RuleFor(u => u.Password).NotEmpty().Length(2, 30).WithMessage("{PropertyName} length must be between 2 and 30 characters!")
                .Matches("[a-zA-Z]").Matches("[0-9]").WithMessage("{PropertyName} must contain a character and a number!")
                .Matches("[^a-zA-Z0-9]").WithMessage("{PropertyName} must not contain special character!"); 
        }
    }
}
