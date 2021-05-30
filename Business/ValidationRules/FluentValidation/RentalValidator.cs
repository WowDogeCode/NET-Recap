﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).NotEmpty().LessThan(DateTime.Now.AddSeconds(1));
            RuleFor(r => r.ReturnDate).GreaterThan(r => r.RentDate).When(r => r.ReturnDate.HasValue);
        }
    }
}
