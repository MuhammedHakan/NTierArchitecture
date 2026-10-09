using FluentValidation;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Business.Validators;

public class TeacherValidator : AbstractValidator<Teacher>
{
    public TeacherValidator()
    {
        RuleFor(Teacher => Teacher.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");
        RuleFor(Teacher => Teacher.Phone)
            .NotEmpty().WithMessage("Phone is required.")
            .Length(3, 30).WithMessage("Phone must be between 3 and 30 characters.");
        RuleFor(Teacher => Teacher.Branch)
            .NotEmpty().WithMessage("Branch is required.")
            .Length(2, 50).WithMessage("Branch must be between 2 and 50 characters.");
        RuleFor(Teacher => Teacher.LessonID)
            .NotEmpty().WithMessage("LessonID is required.")
            .GreaterThan(0).WithMessage("LessonID must be greater than 0.");
    }
}
