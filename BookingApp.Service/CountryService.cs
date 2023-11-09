using BookingApp.DTO;
using BookingApp.Facade.Repositories;

namespace BookingApp.Service;

public class CountryService
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
}