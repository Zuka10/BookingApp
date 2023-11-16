using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.DTO.Services;

public class Salon
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [MaxLength(255)]
    public string? Description { get; set; }

    public City City { get; set; } = null!;
}