using BookingApp.DTO.Services;
using BookingApp.Facade.Repositories;

namespace BookingApp.Repository;

internal class SpaRepository : RepositoryBase<Spa>, ISpaRepository
{
    public SpaRepository(BookingAppDbContext context) : base(context) { }
}