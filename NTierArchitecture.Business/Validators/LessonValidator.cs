using FluentValidation;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Business.Validators;

public class LessonValidator : AbstractValidator<Lesson>
{
    public LessonValidator()
    {
        RuleFor(Lesson => Lesson.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");
        RuleFor(Lesson => Lesson.WeeklyHour)
            .NotEmpty().WithMessage("Duration is required.")
            .GreaterThan(0).WithMessage("Duration must be greater than 0.");
    }
}
