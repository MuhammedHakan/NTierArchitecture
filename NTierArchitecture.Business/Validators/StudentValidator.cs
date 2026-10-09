using FluentValidation;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Business.Validators;
public class StudentValidator : AbstractValidator<Student>
{
    public StudentValidator()
    {
        RuleFor(student => student.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");
        RuleFor(student => student.Phone)
            .NotEmpty().WithMessage("Phone is required.")
            .Length(3,30).WithMessage("Phone must be between 3 and 30 characters.");
        RuleFor(student => student.DateOfBirth)
            .NotEmpty().WithMessage("Date of Birth is required.")
            .LessThan(DateTime.Now).WithMessage("Date of Birth must be in the past.");
        RuleFor(student => student.Gender)
            .NotEmpty().WithMessage("Gender is required.");
    }
}
