using FluentValidation;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Business.Validators;

public class DiscontinuityValidator : AbstractValidator<Discontinuity>
{
    public DiscontinuityValidator()
    {
        RuleFor(Discontinuity => Discontinuity.StudentID)
            .NotEmpty().WithMessage("StudentID is required.")
            .GreaterThan(0).WithMessage("StudentID must be greater than 0.");
        RuleFor(Discontinuity => Discontinuity.DateofDiscontinuity)
            .NotEmpty().WithMessage("Date of Discontinuity is required.")
            .LessThan(DateTime.Now).WithMessage("Date of Discontinuity must be in the past.");
        RuleFor(Discontinuity => Discontinuity.Days)
            .LessThan(30).WithMessage("Days must be less than 30.");
    }
}
