using BookingApp.DTO;
using BookingApp.Facade.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Controllers;

[ApiController]
[Route("api/account")]
public class AccountApiController : ControllerBase
{
    private ICustomerService _customerService;
    private ITokenService _tokenService;
    private readonly ILogger<AccountApiController> _logger;

    public AccountApiController(ICustomerService customerService, ITokenService tokenService, ILogger<AccountApiController> logger)
    {
        _customerService = customerService;
        _logger = logger;
        _tokenService = tokenService;
    }

    [HttpPost]
    [Route("register")]
    public IActionResult Register(Customer customer)
    {
        try
        {
            _customerService.CreateCustomer(customer);
            return Ok(customer);
        }
        catch (Exception ex)
        {
            _logger.LogError(message: ex.Message);
            return BadRequest();
        }
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login(string email, string password)
    {
        var authenticatedCustomer = _customerService.Authenticate(email, password);

        if (authenticatedCustomer != null)
        {
            var token = _tokenService.GenerateToken(authenticatedCustomer);
            return Ok(token);
        }
        return BadRequest("Invalid email or password");
    }

    [HttpPost]
    [Route("logout")]
    public IActionResult Logout()
    {
        // Perform any necessary logout logic
        // For example, you might invalidate the user's authentication token

        return Ok("Logout successful");
    }

}
