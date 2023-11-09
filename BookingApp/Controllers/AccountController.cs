using BookingApp.DTO;
using BookingApp.Facade;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Controllers
{
    public class AccountController : Controller
    {
        private ICustomerService _service;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ICustomerService service, ILogger<AccountController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            try
            {
                _service.Register(customer);
                // Redirect to a confirmation page or login page after successful registration
                return Ok("sg dzma klanshi ginda?");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                _logger.LogError(message: ex.Message);
                ModelState.AddModelError(string.Empty, "An error occurred during registration.");
                return View(customer);
            }
        }

        public IActionResult RegistrationConfirmation()
        {
            // You can create a view for the registration confirmation page
            return View();
        }
    }
}
