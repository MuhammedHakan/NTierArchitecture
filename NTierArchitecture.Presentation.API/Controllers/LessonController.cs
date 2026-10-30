using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Services;
using NTierArchitecture.Domain.Entities;
using NTierArchitecture.Presentation.API.DTOs;

namespace NTierArchitecture.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController(LessonServices lessonServices, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLessons()
        {
            var lessons = lessonServices.GetAll() ?? [];
            var lessonDTOs = mapper.Map<List<LessonDTO>>(lessons);
            return Ok(lessonDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetLessonById(int id)
        {
            var lesson = lessonServices.GetById(id);
            if (lesson == null)
                return NotFound($"Lesson with ID {id} was not found.");

            return Ok(mapper.Map<LessonDTO>(lesson));
        }

        [HttpPost]
        public IActionResult AddLesson(LessonDTO lessonDTO)
        {
            var lesson = mapper.Map<Lesson>(lessonDTO);
            lessonServices.Create(lesson);
            return Ok("Lesson added successfully.");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateLesson(int id, LessonDTO lessonDTO)
        {
            var lesson = lessonServices.GetById(id);
            if (lesson == null)
                return NotFound($"Lesson with ID {id} was not found.");

            mapper.Map(lessonDTO, lesson);
            lesson.ID = id;

            lessonServices.Update(lesson);
            return Ok("Lesson updated successfully.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteLesson(int id)
        {
            var lesson = lessonServices.GetById(id);
            if (lesson == null)
                return NotFound($"Lesson with ID {id} was not found.");

            lessonServices.DeleteById(id);
            return Ok("Lesson deleted successfully.");
        }
    }
}
