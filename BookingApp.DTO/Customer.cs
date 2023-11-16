using System.ComponentModel.DataAnnotations;

namespace BookingApp.DTO;

public class Customer
{
    public int Id { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name is required")]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Birth date is required")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be greater than 8 symbol"), MaxLength(16, ErrorMessage = "Password must be less than 16 symbol")]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Personal number is required")]
    [MinLength(11, ErrorMessage = "Personal Number should contain 11 digits"), MaxLength(11, ErrorMessage = "Personal Number should contain 11 digits")]
    public string PersonalNumber { get; set; } = null!;

    [Required(ErrorMessage = "Address is required")]
    [MaxLength(100)]
    public string Address { get; set; } = null!;

    //public City City { get; set;} = null!; 
}