using System.ComponentModel.DataAnnotations;

namespace BookingApp.DTO;

public class City
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public Country? Country { get; set; }
}