using BookingApp.DTO;
using BookingApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Controllers
{
    public class AccountController : Controller
    {
        private CustomerService _service;

        public AccountController(CustomerService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            try
            {
                _service.Register(customer);
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
