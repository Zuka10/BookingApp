using BookingApp.DTO;
using BookingApp.Facade;
using BookingApp.Facade.Repositories;

namespace BookingApp.Service;

public class CustomerService : ICustomerService
{
    private IUnitOfWork _unitOfWork;

    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Register(Customer customer)
    {
        _unitOfWork.CustomerRepository.Insert(customer);
        _unitOfWork.SaveChanges();
    }

    public void DeleteCustomer(Customer customer)
    {
        _unitOfWork.CustomerRepository.Get(customer);
        if (customer != null)
        {
            _unitOfWork.CustomerRepository.Delete(customer);
        }
    }
}