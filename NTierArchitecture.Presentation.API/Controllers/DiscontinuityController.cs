using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Services;
using NTierArchitecture.Domain.Entities;
using NTierArchitecture.Presentation.API.DTOs;

namespace NTierArchitecture.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscontinuityController(DiscontinuityServices discontinuityServices, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDiscontinuities()
        {
            var discontinuities = discontinuityServices.GetAll() ?? [];
            var discontinuityDTOs = mapper.Map<List<DiscontinuityDTO>>(discontinuities);
            return Ok(discontinuityDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDiscontinuityById(int id)
        {
            var discontinuity = discontinuityServices.GetById(id);
            if (discontinuity == null)
                return NotFound($"Discontinuity with ID {id} was not found.");

            return Ok(mapper.Map<DiscontinuityDTO>(discontinuity));
        }

        [HttpPost]
        public IActionResult AddDiscontinuity(DiscontinuityDTO discontinuityDTO)
        {
            var discontinuity = mapper.Map<Discontinuity>(discontinuityDTO);
            discontinuityServices.Create(discontinuity);
            return Ok("Discontinuity added successfully.");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateDiscontinuity(int id, DiscontinuityDTO discontinuityDTO)
        {
            var discontinuity = discontinuityServices.GetById(id);
            if (discontinuity == null)
                return NotFound($"Discontinuity with ID {id} was not found.");

            mapper.Map(discontinuityDTO, discontinuity);
            discontinuity.ID = id;

            discontinuityServices.Update(discontinuity);
            return Ok("Discontinuity updated successfully.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteDiscontinuity(int id)
        {
            var discontinuity = discontinuityServices.GetById(id);
            if (discontinuity == null)
                return NotFound($"Discontinuity with ID {id} was not found.");

            discontinuityServices.DeleteById(id);
            return Ok("Discontinuity deleted successfully.");
        }
    }
}
