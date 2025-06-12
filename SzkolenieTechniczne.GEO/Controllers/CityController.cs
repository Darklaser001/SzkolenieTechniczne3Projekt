using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.GEO.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("geo")]
public class CityController : ControllerBase
{
    private readonly CityService _cityService;

    public CityController(CityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet("cities")]
    public async Task<IEnumerable<CityDto>> GetAllAsync()
    {
        var cities = await _cityService.Get();

        return cities;
    }

    [HttpGet("cities/{id}")]
    public async Task<IActionResult> ReadById(Guid id)
    {
        var cityDto = await _cityService.GetById(id);

        if (cityDto == null)
        {
            return NotFound();
        }

        return Ok(cityDto);
    }

    [HttpPost("city")]
    public async Task<IActionResult> Create([FromBody] CityDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var operationResult = await _cityService.Create(dto);

        return Ok(operationResult.Result);
    }
}