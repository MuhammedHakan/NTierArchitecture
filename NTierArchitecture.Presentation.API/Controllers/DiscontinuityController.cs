using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Services;
using NTierArchitecture.Domain.Entities;
using NTierArchitecture.Presentation.API.DTOs;

namespace NTierArchitecture.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscontinuityController(DiscontinuityServices discontinuityServices) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDiscontinuities()
        {
            var discontinuities = discontinuityServices.GetAll() ?? [];
            List<DiscontinuityDTO> discontinuityDTOs = discontinuities.Select(ToDTO).ToList();
            return Ok(discontinuityDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDiscontinuityById(int id)
        {
            var discontinuity = discontinuityServices.GetById(id);
            if (discontinuity == null)
                return NotFound($"Discontinuity with ID {id} was not found.");

            return Ok(ToDTO(discontinuity));
        }

        [HttpPost]
        public IActionResult AddDiscontinuity(DiscontinuityDTO discontinuityDTO)
        {
            var discontinuity = new Discontinuity
            {
                StudentID = discontinuityDTO.StudentID,
                DateofDiscontinuity = discontinuityDTO.DateofDiscontinuity,
                Days = discontinuityDTO.Days,
                Excuse = discontinuityDTO.Excuse
            };

            try
            {
                discontinuityServices.Create(discontinuity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Discontinuity added successfully.");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateDiscontinuity(int id, DiscontinuityDTO discontinuityDTO)
        {
            var discontinuity = discontinuityServices.GetById(id);
            if (discontinuity == null)
                return NotFound($"Discontinuity with ID {id} was not found.");

            discontinuity.StudentID = discontinuityDTO.StudentID;
            discontinuity.DateofDiscontinuity = discontinuityDTO.DateofDiscontinuity;
            discontinuity.Days = discontinuityDTO.Days;
            discontinuity.Excuse = discontinuityDTO.Excuse;

            try
            {
                discontinuityServices.Update(discontinuity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Discontinuity updated successfully.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteDiscontinuity(int id)
        {
            var discontinuity = discontinuityServices.GetById(id);
            if (discontinuity == null)
                return NotFound($"Discontinuity with ID {id} was not found.");

            try
            {
                discontinuityServices.DeleteById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Discontinuity deleted successfully.");
        }

        private static DiscontinuityDTO ToDTO(Discontinuity discontinuity) => new()
        {
            ID = discontinuity.ID,
            StudentID = discontinuity.StudentID,
            DateofDiscontinuity = discontinuity.DateofDiscontinuity,
            Days = discontinuity.Days,
            Excuse = discontinuity.Excuse,
            StudentName = discontinuity.Student?.Name
        };
    }
}
