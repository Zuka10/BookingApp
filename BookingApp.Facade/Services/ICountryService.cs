using BookingApp.DTO;

namespace BookingApp.Facade.Services;

public interface ICountryService
{
    void Create(Country country);
    void Update(Country country);
    void Delete(Country country);
    Country GetById(int id);
    IEnumerable<Country> GetAll();
}
