using FluentValidation;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Business.Validators;

public class ClassValidator : AbstractValidator<Class>
{
    public ClassValidator()
    {
        RuleFor(Class => Class.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");
        RuleFor(Class => Class.Capacity)
            .NotEmpty().WithMessage("Capacity is required.")
            .GreaterThan(0).WithMessage("Capacity must be greater than 0.");
    }
}
