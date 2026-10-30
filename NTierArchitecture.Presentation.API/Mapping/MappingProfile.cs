using AutoMapper;
using NTierArchitecture.Domain.Entities;
using NTierArchitecture.Presentation.API.DTOs;

namespace NTierArchitecture.Presentation.API.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Class
        CreateMap<Class, ClassDTO>().ReverseMap();

        // Student
        CreateMap<Student, StudentDTO>()
            .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class != null ? src.Class.Name : null));
        CreateMap<StudentDTO, Student>()
            .ForMember(dest => dest.Class, opt => opt.Ignore());

        // Teacher
        CreateMap<Teacher, TeacherDTO>()
            .ForMember(dest => dest.LessonName, opt => opt.MapFrom(src => src.Lesson != null ? src.Lesson.Name : null));
        CreateMap<TeacherDTO, Teacher>()
            .ForMember(dest => dest.Lesson, opt => opt.Ignore());

        // Lesson
        CreateMap<Lesson, LessonDTO>().ReverseMap();

        // Exam
        CreateMap<Exam, ExamDTO>()
            .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student != null ? src.Student.Name : null))
            .ForMember(dest => dest.LessonName, opt => opt.MapFrom(src => src.Lesson != null ? src.Lesson.Name : null));
        CreateMap<ExamDTO, Exam>()
            .ForMember(dest => dest.Student, opt => opt.Ignore())
            .ForMember(dest => dest.Lesson, opt => opt.Ignore());

        // Discontinuity
        CreateMap<Discontinuity, DiscontinuityDTO>()
            .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student != null ? src.Student.Name : null));
        CreateMap<DiscontinuityDTO, Discontinuity>()
            .ForMember(dest => dest.Student, opt => opt.Ignore());
    }
}
