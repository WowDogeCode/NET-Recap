using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).
                Cascade(CascadeMode.Stop).NotEmpty().Length(5, 30).
                WithMessage("{PropertyName} length must be between 5 - 30 characters!");
            RuleFor(c => c.DailyPrice).NotEmpty().GreaterThan(0);
            RuleFor(c => c.Description).NotEmpty().Length(2, 30);
            RuleFor(c => c.ModelYear).NotEmpty();
        }
    }
}
