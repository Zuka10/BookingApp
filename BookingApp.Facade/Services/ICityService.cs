using BookingApp.DTO;

namespace BookingApp.Facade.Services;

public interface ICityService
{
    void Create(City country);
    void Update(City country);
    void Delete(City country);
    City GetById(int id);
    IEnumerable<City> GetAll();
}
