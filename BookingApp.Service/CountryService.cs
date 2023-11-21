using BookingApp.DTO;
using BookingApp.Facade.Repositories;
using BookingApp.Facade.Services;

namespace BookingApp.Service;

public class CountryService : ICountryService
{
    private IUnitOfWork _unitOfWork;

    public CountryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(Country country)
    {
        _unitOfWork.CountryRepository.Insert(country);
        _unitOfWork.SaveChanges();
    }

    public void Update(Country country)
    {
        var existingCountry = _unitOfWork.CountryRepository.Get(country.Id);
        existingCountry.Name = country.Name;
        existingCountry.Cities = country.Cities;
        _unitOfWork.CountryRepository.Update(existingCountry);
        _unitOfWork.SaveChanges();
    }

    public void Delete(Country country)
    {
        var existingCountry = _unitOfWork.CountryRepository.Get(country.Id);
        if (existingCountry != null)
        {
            _unitOfWork.CountryRepository.Delete(country);
            _unitOfWork.SaveChanges();
        }
    }

    public Country GetById(int id)
    {
        var country = _unitOfWork.CountryRepository.Get(id);
        _unitOfWork.SaveChanges();
        return country;
    }

    public IEnumerable<Country> GetAll()
    {
        var countries = _unitOfWork.CountryRepository.GetAll();
        return countries;
    }
}