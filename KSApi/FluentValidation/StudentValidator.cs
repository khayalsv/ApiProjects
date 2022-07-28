using FluentValidation;
using KSApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSApi.FluentValidation
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Name).Length(3, 10);
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Please enter the surname");
            RuleFor(x => x.Salary).InclusiveBetween(100, 1000);
            RuleFor(x => x.GenderID).InclusiveBetween(1, 3);
            RuleFor(x => x.GenderID).GreaterThan(1);
        }
    }
}
