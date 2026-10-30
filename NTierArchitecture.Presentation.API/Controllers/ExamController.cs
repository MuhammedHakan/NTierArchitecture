using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Services;
using NTierArchitecture.Domain.Entities;
using NTierArchitecture.Presentation.API.DTOs;

namespace NTierArchitecture.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController(ExamServices examServices, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetExams()
        {
            var exams = examServices.GetAll() ?? [];
            var examDTOs = mapper.Map<List<ExamDTO>>(exams);
            return Ok(examDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetExamById(int id)
        {
            var exam = examServices.GetById(id);
            if (exam == null)
                return NotFound($"Exam with ID {id} was not found.");

            return Ok(mapper.Map<ExamDTO>(exam));
        }

        [HttpPost]
        public IActionResult AddExam(ExamDTO examDTO)
        {
            var exam = mapper.Map<Exam>(examDTO);
            examServices.Create(exam);
            return Ok("Exam added successfully.");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateExam(int id, ExamDTO examDTO)
        {
            var exam = examServices.GetById(id);
            if (exam == null)
                return NotFound($"Exam with ID {id} was not found.");

            mapper.Map(examDTO, exam);
            exam.ID = id;

            examServices.Update(exam);
            return Ok("Exam updated successfully.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteExam(int id)
        {
            var exam = examServices.GetById(id);
            if (exam == null)
                return NotFound($"Exam with ID {id} was not found.");

            examServices.DeleteById(id);
            return Ok("Exam deleted successfully.");
        }
    }
}
