using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Services;
using NTierArchitecture.Domain.Entities;
using NTierArchitecture.Presentation.API.DTOs;

namespace NTierArchitecture.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController(TeacherServices teacherServices) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTeachers()
        {
            var teachers = teacherServices.GetAll() ?? [];
            List<TeacherDTO> teacherDTOs = teachers.Select(ToDTO).ToList();
            return Ok(teacherDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetTeacherById(int id)
        {
            var teacher = teacherServices.GetById(id);
            if (teacher == null)
                return NotFound($"Teacher with ID {id} was not found.");

            return Ok(ToDTO(teacher));
        }

        [HttpPost]
        public IActionResult AddTeacher(TeacherDTO teacherDTO)
        {
            var teacher = new Teacher
            {
                Name = teacherDTO.Name,
                Branch = teacherDTO.Branch,
                Phone = teacherDTO.Phone,
                LessonID = teacherDTO.LessonID
            };

            try
            {
                teacherServices.Create(teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Teacher added successfully.");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateTeacher(int id, TeacherDTO teacherDTO)
        {
            var teacher = teacherServices.GetById(id);
            if (teacher == null)
                return NotFound($"Teacher with ID {id} was not found.");

            teacher.Name = teacherDTO.Name;
            teacher.Branch = teacherDTO.Branch;
            teacher.Phone = teacherDTO.Phone;
            teacher.LessonID = teacherDTO.LessonID;

            try
            {
                teacherServices.Update(teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Teacher updated successfully.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteTeacher(int id)
        {
            var teacher = teacherServices.GetById(id);
            if (teacher == null)
                return NotFound($"Teacher with ID {id} was not found.");

            try
            {
                teacherServices.DeleteById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Teacher deleted successfully.");
        }

        private static TeacherDTO ToDTO(Teacher teacher) => new()
        {
            ID = teacher.ID,
            Name = teacher.Name,
            Branch = teacher.Branch,
            Phone = teacher.Phone,
            LessonID = teacher.LessonID,
            LessonName = teacher.Lesson?.Name
        };
    }
}
