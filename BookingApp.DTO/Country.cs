using System.ComponentModel.DataAnnotations;

namespace BookingApp.DTO;

public class Country
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public ICollection<City>? Cities { get; set; } = null!;
}