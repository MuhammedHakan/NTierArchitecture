using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Services;
using NTierArchitecture.Domain.Entities;
using NTierArchitecture.Presentation.API.DTOs;

namespace NTierArchitecture.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController(ClassServices classServices) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetClasses()
        {
            var classes = classServices.GetAll() ?? [];
            List<ClassDTO> classDTOs = classes.Select(ToDTO).ToList();
            return Ok(classDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetClassById(int id)
        {
            var entity = classServices.GetById(id);
            if (entity == null)
                return NotFound($"Class with ID {id} was not found.");

            return Ok(ToDTO(entity));
        }

        [HttpPost]
        public IActionResult AddClass(ClassDTO classDTO)
        {
            var entity = new Class
            {
                Name = classDTO.Name,
                Capacity = classDTO.Capacity
            };

            try
            {
                classServices.Create(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Class added successfully.");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateClass(int id, ClassDTO classDTO)
        {
            var entity = classServices.GetById(id);
            if (entity == null)
                return NotFound($"Class with ID {id} was not found.");

            entity.Name = classDTO.Name;
            entity.Capacity = classDTO.Capacity;

            try
            {
                classServices.Update(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Class updated successfully.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteClass(int id)
        {
            var entity = classServices.GetById(id);
            if (entity == null)
                return NotFound($"Class with ID {id} was not found.");

            try
            {
                classServices.DeleteById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Class deleted successfully.");
        }

        private static ClassDTO ToDTO(Class entity) => new()
        {
            ID = entity.ID,
            Name = entity.Name,
            Capacity = entity.Capacity
        };
    }
}
