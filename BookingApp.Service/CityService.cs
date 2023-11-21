using BookingApp.DTO;
using BookingApp.Facade.Repositories;
using BookingApp.Facade.Services;

namespace BookingApp.Service;

public class CityService : ICityService
{
    private IUnitOfWork _unitOfWork;

    public CityService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(City city)
    {
        _unitOfWork.CityRepository.Insert(city);
        _unitOfWork.SaveChanges();
    }

    public void Update(City city)
    {
        var existingCity = _unitOfWork.CityRepository.Get(city.Id);
        existingCity.Name = city.Name;
        existingCity.Country = city.Country;
        _unitOfWork.CityRepository.Update(existingCity);
        _unitOfWork.SaveChanges();
    }

    public void Delete(City city)
    {
        var existingCity = _unitOfWork.CityRepository.Get(city.Id);
        if (existingCity != null)
        {
            _unitOfWork.CityRepository.Delete(city);
            _unitOfWork.SaveChanges();
        }
    }

    public City GetById(int id)
    {
        var city = _unitOfWork.CityRepository.Get(id);
        _unitOfWork.SaveChanges();
        return city;
    }

    public IEnumerable<City> GetAll()
    {
        var cities = _unitOfWork.CityRepository.GetAll();
        return cities;
    }
}
