using BookingApp.DTO;
using BookingApp.Facade.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Controllers
{
    public class CountryController : Controller
    {
        private ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            var countries = _countryService.GetAll(); // Assuming you have a method to get all countries
            return View(countries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _countryService.Create(country);
                return RedirectToAction("Index", "Country");
            }

            return View(country);
        }

        public IActionResult Edit(int id)
        {
            var country = _countryService.GetById(id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _countryService.Update(country);
                return RedirectToAction("Index", "Country");
            }

            return View(country);
        }

        public IActionResult Delete(int id)
        {
            var country = _countryService.GetById(id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var country = _countryService.GetById(id);

            if (country != null)
            {
                _countryService.Delete(country);
            }

            return RedirectToAction("Index", "Country");
        }
    }
}
