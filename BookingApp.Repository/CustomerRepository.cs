using BookingApp.DTO;
using BookingApp.Facade.Repositories;

namespace BookingApp.Repository;

internal class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(BookingAppDbContext context) : base(context) { }
}