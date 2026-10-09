using FluentValidation;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Business.Validators;

public class ExamValidator : AbstractValidator<Exam>
{
    public ExamValidator()
    {
        RuleFor(Exam => Exam.LessonID)
            .NotEmpty().WithMessage("LessonID is required.")
            .GreaterThan(0).WithMessage("LessonID must be greater than 0.");
        RuleFor(Exam => Exam.StudentID)
            .NotEmpty().WithMessage("StudentID is required.")
            .GreaterThan(0).WithMessage("StudentID must be greater than 0.");
        RuleFor(Exam => Exam.ExamDate)
            .NotEmpty().WithMessage("Exam Date is required.")
            .LessThan(DateTime.Now).WithMessage("Exam Date must be in the past.");
        RuleFor(Exam => Exam.Duration)
            .NotEmpty().WithMessage("Duration is required.")
            .GreaterThan(0).WithMessage("Duration must be greater than 0.");
        RuleFor(Exam => Exam.Note)
            .NotEmpty().WithMessage("Note is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Note must be greater than or equal to 0.")
            .LessThanOrEqualTo(100).WithMessage("Note must be less than or equal to 100.");
        RuleFor(Exam => Exam.IsSecondary)
            .NotEmpty().WithMessage("IsSecondary is required.");
    }
}
