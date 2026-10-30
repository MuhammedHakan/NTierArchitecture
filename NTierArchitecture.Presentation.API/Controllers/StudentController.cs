using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Services;
using NTierArchitecture.Domain.Entities;
using NTierArchitecture.Presentation.API.DTOs;

namespace NTierArchitecture.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(StudentServices studentServices) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = studentServices.GetAll() ?? [];
            List<StudentDTO> studentDTOs = students.Select(ToDTO).ToList();
            return Ok(studentDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudentById(int id)
        {
            var student = studentServices.GetById(id);
            if (student == null)
                return NotFound($"Student with ID {id} was not found.");

            return Ok(ToDTO(student));
        }

        [HttpPost]
        public IActionResult AddStudent(StudentDTO studentDTO)
        {
            var student = new Student
            {
                Name = studentDTO.Name,
                Gender = studentDTO.Gender,
                DateOfBirth = studentDTO.DateOfBirth,
                Phone = studentDTO.Phone,
                ClassID = studentDTO.ClassID
            };

            try
            {
                studentServices.Create(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Student added successfully.");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateStudent(int id, StudentDTO studentDTO)
        {
            var student = studentServices.GetById(id);
            if (student == null)
                return NotFound($"Student with ID {id} was not found.");

            student.Name = studentDTO.Name;
            student.Gender = studentDTO.Gender;
            student.DateOfBirth = studentDTO.DateOfBirth;
            student.Phone = studentDTO.Phone;
            student.ClassID = studentDTO.ClassID;

            try
            {
                studentServices.Update(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Student updated successfully.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = studentServices.GetById(id);
            if (student == null)
                return NotFound($"Student with ID {id} was not found.");

            try
            {
                studentServices.DeleteById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Student deleted successfully.");
        }

        private static StudentDTO ToDTO(Student student) => new()
        {
            ID = student.ID,
            Name = student.Name,
            Gender = student.Gender,
            DateOfBirth = student.DateOfBirth,
            Phone = student.Phone,
            ClassID = student.ClassID,
            ClassName = student.Class?.Name
        };
    }
}
