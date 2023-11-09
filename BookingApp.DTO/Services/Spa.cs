namespace BookingApp.DTO.Services;

public class Spa
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }

    public City City { get; set; } = null!;
}