using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Services;
using NTierArchitecture.Domain.Entities;
using NTierArchitecture.Presentation.API.DTOs;

namespace NTierArchitecture.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(StudentServices studentServices, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = studentServices.GetAll() ?? [];
            var studentDTOs = mapper.Map<List<StudentDTO>>(students);
            return Ok(studentDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudentById(int id)
        {
            var student = studentServices.GetById(id);
            if (student == null)
                return NotFound($"Student with ID {id} was not found.");

            return Ok(mapper.Map<StudentDTO>(student));
        }

        [HttpPost]
        public IActionResult AddStudent(StudentDTO studentDTO)
        {
            var student = mapper.Map<Student>(studentDTO);
            studentServices.Create(student);
            return Ok("Student added successfully.");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateStudent(int id, StudentDTO studentDTO)
        {
            var student = studentServices.GetById(id);
            if (student == null)
                return NotFound($"Student with ID {id} was not found.");

            mapper.Map(studentDTO, student);
            student.ID = id;

            studentServices.Update(student);
            return Ok("Student updated successfully.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = studentServices.GetById(id);
            if (student == null)
                return NotFound($"Student with ID {id} was not found.");

            studentServices.DeleteById(id);
            return Ok("Student deleted successfully.");
        }
    }
}
