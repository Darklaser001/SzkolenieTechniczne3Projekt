using Microsoft.AspNetCore.Mvc;
using SzkolenieTechniczne.FitnessClub.CrossCutting.Dtos;
using SzkolenieTechniczne.FitnessClub.Services;

namespace SzkolenieTechniczne.FitnessClub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FitnessClubController : ControllerBase
    {
        private readonly FitnessClubService _service;

        public FitnessClubController(FitnessClubService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _service.GetAllAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var FitnessClub = await _service.GetByIdAsync(id);
            return FitnessClub is null ? NotFound() : Ok(FitnessClub);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FitnessClubDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}