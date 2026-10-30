using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Services;
using NTierArchitecture.Domain.Entities;
using NTierArchitecture.Presentation.API.DTOs;

namespace NTierArchitecture.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController(ExamServices examServices) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetExams()
        {
            var exams = examServices.GetAll() ?? [];
            List<ExamDTO> examDTOs = exams.Select(ToDTO).ToList();
            return Ok(examDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetExamById(int id)
        {
            var exam = examServices.GetById(id);
            if (exam == null)
                return NotFound($"Exam with ID {id} was not found.");

            return Ok(ToDTO(exam));
        }

        [HttpPost]
        public IActionResult AddExam(ExamDTO examDTO)
        {
            var exam = new Exam
            {
                LessonID = examDTO.LessonID,
                StudentID = examDTO.StudentID,
                ExamDate = examDTO.ExamDate,
                Duration = examDTO.Duration,
                IsSecondary = examDTO.IsSecondary,
                Note = examDTO.Note
            };

            try
            {
                examServices.Create(exam);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Exam added successfully.");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateExam(int id, ExamDTO examDTO)
        {
            var exam = examServices.GetById(id);
            if (exam == null)
                return NotFound($"Exam with ID {id} was not found.");

            exam.LessonID = examDTO.LessonID;
            exam.StudentID = examDTO.StudentID;
            exam.ExamDate = examDTO.ExamDate;
            exam.Duration = examDTO.Duration;
            exam.IsSecondary = examDTO.IsSecondary;
            exam.Note = examDTO.Note;

            try
            {
                examServices.Update(exam);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Exam updated successfully.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteExam(int id)
        {
            var exam = examServices.GetById(id);
            if (exam == null)
                return NotFound($"Exam with ID {id} was not found.");

            try
            {
                examServices.DeleteById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Exam deleted successfully.");
        }

        private static ExamDTO ToDTO(Exam exam) => new()
        {
            ID = exam.ID,
            LessonID = exam.LessonID,
            StudentID = exam.StudentID,
            ExamDate = exam.ExamDate,
            Duration = exam.Duration,
            IsSecondary = exam.IsSecondary,
            Note = exam.Note,
            StudentName = exam.Student?.Name,
            LessonName = exam.Lesson?.Name
        };
    }
}
