using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Services;
using NTierArchitecture.Domain.Entities;
using NTierArchitecture.Presentation.API.DTOs;

namespace NTierArchitecture.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController(ClassServices classServices, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetClasses()
        {
            var classes = classServices.GetAll() ?? [];
            var classDTOs = mapper.Map<List<ClassDTO>>(classes);
            return Ok(classDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetClassById(int id)
        {
            var entity = classServices.GetById(id);
            if (entity == null)
                return NotFound($"Class with ID {id} was not found.");

            return Ok(mapper.Map<ClassDTO>(entity));
        }

        [HttpPost]
        public IActionResult AddClass(ClassDTO classDTO)
        {
            var entity = mapper.Map<Class>(classDTO);
            classServices.Create(entity);
            return Ok("Class added successfully.");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateClass(int id, ClassDTO classDTO)
        {
            var entity = classServices.GetById(id);
            if (entity == null)
                return NotFound($"Class with ID {id} was not found.");

            mapper.Map(classDTO, entity);
            entity.ID = id;

            classServices.Update(entity);
            return Ok("Class updated successfully.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteClass(int id)
        {
            var entity = classServices.GetById(id);
            if (entity == null)
                return NotFound($"Class with ID {id} was not found.");

            classServices.DeleteById(id);
            return Ok("Class deleted successfully.");
        }
    }
}
