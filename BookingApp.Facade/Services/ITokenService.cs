using BookingApp.DTO;

namespace BookingApp.Facade.Services;

public interface ITokenService
{
    string GenerateToken(Customer customer);
}
