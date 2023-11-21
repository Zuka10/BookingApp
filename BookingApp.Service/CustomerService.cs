using BookingApp.DTO;
using BookingApp.Facade.Repositories;
using BookingApp.Facade.Services;

namespace BookingApp.Service;

public class CustomerService : ICustomerService
{
    private IUnitOfWork _unitOfWork;

    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void CreateCustomer(Customer customer)
    {
        _unitOfWork.CustomerRepository.Insert(customer);
        _unitOfWork.SaveChanges();
    }

    public void DeleteCustomer(Customer customer)
    {
        _unitOfWork.CustomerRepository.Get(customer.Id);
        if (customer != null)
        {
            _unitOfWork.CustomerRepository.Delete(customer);
        }
    }
    public Customer Authenticate(string email, string password)
    {
        var customer = GetByEmail(email);

        if (customer != null && VerifyPassword(password, customer.Password))
        {
            return customer;
        }

        // Authentication failed
        return null;
    }

    private bool VerifyPassword(string enteredPassword, string storedPassword)
    {
        // Implement your password verification logic (e.g., hashing)
        // For simplicity, this example assumes plain text comparison
        return enteredPassword == storedPassword;
    }

    private Customer GetByEmail(string email)
    {
        return _unitOfWork.CustomerRepository.Find(e => e.Email == email);
    }
}