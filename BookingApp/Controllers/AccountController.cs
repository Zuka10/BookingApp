using BookingApp.DTO;
using BookingApp.Facade.Services;
using BookingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Controllers;

public class AccountController : Controller
{
    private ICustomerService _customerService;
    private ITokenService _tokenService;
    private readonly ILogger<AccountController> _logger;

    public AccountController(ICustomerService customerService, ITokenService tokenService, ILogger<AccountController> logger)
    {
        _customerService = customerService;
        _logger = logger;
        _tokenService = tokenService;
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
            _customerService.CreateCustomer(customer);
            return RedirectToAction("Login");
        }
        catch (Exception ex)
        {
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
            var authenticatedCustomer = _customerService.Authenticate(loginViewModel.Email, loginViewModel.Password);

            if (authenticatedCustomer != null)
            {
                var token = _tokenService.GenerateToken(authenticatedCustomer);
                Response.Headers.Add("Authorization", "Bearer " + token);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
            }
        }

        return View(loginViewModel);
    }
}
