using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Services;
using NTierArchitecture.Domain.Entities;
using NTierArchitecture.Presentation.API.DTOs;

namespace NTierArchitecture.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController(TeacherServices teacherServices, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTeachers()
        {
            var teachers = teacherServices.GetAll() ?? [];
            var teacherDTOs = mapper.Map<List<TeacherDTO>>(teachers);
            return Ok(teacherDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetTeacherById(int id)
        {
            var teacher = teacherServices.GetById(id);
            if (teacher == null)
                return NotFound($"Teacher with ID {id} was not found.");

            return Ok(mapper.Map<TeacherDTO>(teacher));
        }

        [HttpPost]
        public IActionResult AddTeacher(TeacherDTO teacherDTO)
        {
            var teacher = mapper.Map<Teacher>(teacherDTO);
            teacherServices.Create(teacher);
            return Ok("Teacher added successfully.");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateTeacher(int id, TeacherDTO teacherDTO)
        {
            var teacher = teacherServices.GetById(id);
            if (teacher == null)
                return NotFound($"Teacher with ID {id} was not found.");

            mapper.Map(teacherDTO, teacher);
            teacher.ID = id;

            teacherServices.Update(teacher);
            return Ok("Teacher updated successfully.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteTeacher(int id)
        {
            var teacher = teacherServices.GetById(id);
            if (teacher == null)
                return NotFound($"Teacher with ID {id} was not found.");

            teacherServices.DeleteById(id);
            return Ok("Teacher deleted successfully.");
        }
    }
}
