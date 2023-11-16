using BookingApp.DTO;
using BookingApp.Facade.Services;
using BookingApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookingApp.Controllers;

public class CityController : Controller
{
    private ICityService _cityService;
    private ICountryService _countryService;

    public CityController(ICityService cityService, ICountryService countryService)
    {
        _cityService = cityService;
        _countryService = countryService;
    }

    public IActionResult Index()
    {
        var cities = _cityService.GetAll();
        return View(cities);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(City city)
    {
        if (ModelState.IsValid)
        {
            _cityService.Create(city);
            return RedirectToAction("Index", "City");
        }

        return View(city);
    }


    public IActionResult Edit(int id)
    {
        var city = _cityService.GetById(id);

        if (city == null)
        {
            return NotFound();
        }

        return View(city);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, City city)
    {
        if (id != city.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _cityService.Update(city);
            return RedirectToAction("Index", "City");
        }

        return View(city);
    }

    public IActionResult Delete(int id)
    {
        var city = _cityService.GetById(id);

        if (city == null)
        {
            return NotFound();
        }

        return View(city);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var city = _cityService.GetById(id);

        if (city != null)
        {
            _cityService.Delete(city);
        }

        return RedirectToAction("Index", "City");
    }
}
