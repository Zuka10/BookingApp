using BookingApp.DTO;
using BookingApp.Facade.Services;
using BookingApp.Models;
using BookingApp.Service;
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
                _service.CreateCustomer(customer);
                // Redirect to a confirmation page or login page after successful registration
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                _logger.LogError(message: ex.Message);
                ModelState.AddModelError(string.Empty, "An error occurred during registration.");
                return View(customer);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                // Perform authentication logic
                var authenticatedCustomer = _service.Authenticate(loginViewModel.Email, loginViewModel.Password);

                if (authenticatedCustomer != null)
                {
                    // Authentication successful, you can set up a user session or cookie here
                    return Ok("Great you are part of family");
                }
                else
                {
                    // Authentication failed
                    ModelState.AddModelError(string.Empty, "Invalid email or password");
                }
            }

            // If ModelState is not valid, redisplay the login form with validation errors
            return View(loginViewModel);
        }
    }
}
