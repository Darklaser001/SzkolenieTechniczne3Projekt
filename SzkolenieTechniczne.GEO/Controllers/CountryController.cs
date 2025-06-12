using Microsoft.AspNetCore.Mvc;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.GEO.Services;

[Route("geo")]
public class CountryController : ControllerBase
{
    private readonly CountryService _countryService;

    public CountryController(CountryService countryService)
    {
        _countryService = countryService;
    }



    [HttpGet("countries")]
    public async Task<IEnumerable<CountryDto>> GetAllAsync()
    {
        var countries = await _countryService.Get();

        return countries;
    }

    [HttpGet("countries/{id}")]
    public async Task<IActionResult> ReadById(Guid id)
    {
        var cityDto = await _countryService.GetById(id);

        if (cityDto == null)
        {
            return NotFound();
        }

        return Ok(cityDto);
    }


    [HttpPost("country")]
    public async Task<IActionResult> Create([FromBody] CountryDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var operationResult = await _countryService.Create(dto);

        return Ok(operationResult.Result);
    }
}
