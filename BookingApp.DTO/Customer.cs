namespace BookingApp.DTO;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PersonalNumber { get; set; } = null!;
    public string Address { get; set; } = null!;

    public City City { get; set;} = null!; 
}