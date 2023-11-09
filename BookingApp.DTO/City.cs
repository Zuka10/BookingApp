namespace BookingApp.DTO;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public Country Country { get; set; } = null!;
}