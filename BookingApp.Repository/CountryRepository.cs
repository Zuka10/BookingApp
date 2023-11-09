using BookingApp.DTO;
using BookingApp.Facade.Repositories;

namespace BookingApp.Repository;

internal class CountryRepository : RepositoryBase<Country>, ICountryRepository
{
    public CountryRepository(BookingAppDbContext context) : base(context) { }
}