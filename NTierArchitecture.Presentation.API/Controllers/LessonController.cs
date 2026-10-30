using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Services;
using NTierArchitecture.Domain.Entities;
using NTierArchitecture.Presentation.API.DTOs;

namespace NTierArchitecture.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController(LessonServices lessonServices) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLessons()
        {
            var lessons = lessonServices.GetAll() ?? [];
            List<LessonDTO> lessonDTOs = lessons.Select(ToDTO).ToList();
            return Ok(lessonDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetLessonById(int id)
        {
            var lesson = lessonServices.GetById(id);
            if (lesson == null)
                return NotFound($"Lesson with ID {id} was not found.");

            return Ok(ToDTO(lesson));
        }

        [HttpPost]
        public IActionResult AddLesson(LessonDTO lessonDTO)
        {
            var lesson = new Lesson
            {
                Name = lessonDTO.Name,
                WeeklyHour = lessonDTO.WeeklyHour
            };

            try
            {
                lessonServices.Create(lesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Lesson added successfully.");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateLesson(int id, LessonDTO lessonDTO)
        {
            var lesson = lessonServices.GetById(id);
            if (lesson == null)
                return NotFound($"Lesson with ID {id} was not found.");

            lesson.Name = lessonDTO.Name;
            lesson.WeeklyHour = lessonDTO.WeeklyHour;

            try
            {
                lessonServices.Update(lesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Lesson updated successfully.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteLesson(int id)
        {
            var lesson = lessonServices.GetById(id);
            if (lesson == null)
                return NotFound($"Lesson with ID {id} was not found.");

            try
            {
                lessonServices.DeleteById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Lesson deleted successfully.");
        }

        private static LessonDTO ToDTO(Lesson lesson) => new()
        {
            ID = lesson.ID,
            Name = lesson.Name,
            WeeklyHour = lesson.WeeklyHour
        };
    }
}
