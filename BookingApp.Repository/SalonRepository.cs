using BookingApp.DTO.Services;
using BookingApp.Facade.Repositories;
using System.Runtime.CompilerServices;

#if DEBUG
[assembly: InternalsVisibleTo("WarehouseManager.Tests")]
#endif

namespace BookingApp.Repository;

internal class SalonRepository : RepositoryBase<Salon>, ISalonRepository
{
    public SalonRepository(BookingAppDbContext context) : base(context) { }
}