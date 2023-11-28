using BookingApp.DTO;

namespace BookingApp.Facade.Services;

public interface ICustomerService
{
    public void CreateCustomer(Customer customer);
    public void DeleteCustomer(Customer customer);
    public Customer? Authenticate(string email, string password);
}