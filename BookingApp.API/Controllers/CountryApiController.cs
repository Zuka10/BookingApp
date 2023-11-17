using BookingApp.Facade.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/countries")]
[Authorize]
public class CountryApiController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryApiController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public IActionResult GetAllCountries()
    {
        var countries = _countryService.GetAll();
        return Ok(countries);
    }

    [HttpGet("{id}")]
    public IActionResult GetCountryById(int id)
    {
        var country = _countryService.GetById(id);

        if (country == null)
        {
            return NotFound();
        }

        return Ok(country);
    }
}
