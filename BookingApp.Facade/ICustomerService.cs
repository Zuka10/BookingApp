using BookingApp.DTO;

namespace BookingApp.Facade;

public interface ICustomerService
{
    public void Register(Customer customer);
    public void DeleteCustomer(Customer customer);
}