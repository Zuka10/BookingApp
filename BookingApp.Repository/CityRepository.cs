using BookingApp.DTO;
using BookingApp.Facade.Repositories;

namespace BookingApp.Repository;

internal class CityRepository : RepositoryBase<City>, ICityRepository
{
    public CityRepository(BookingAppDbContext context) : base(context) { }
}