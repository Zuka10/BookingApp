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
        _unitOfWork.CountryRepository.Get(country);
        _unitOfWork.CountryRepository.Update(country);
        _unitOfWork.SaveChanges();
    }

    public void Delete(Country country)
    {
        _unitOfWork.CountryRepository.Get(country);
        _unitOfWork.CountryRepository.Delete(country);
        _unitOfWork.SaveChanges();
    }

    public Country GetById(int id)
    {
        var country = _unitOfWork.CountryRepository.Get(id);
        _unitOfWork.SaveChanges();
        return country;
    }

    public IEnumerable<Country> GetAll()
    {
        throw new NotImplementedException();
    }
}