namespace BookingApp.DTO;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public byte[]? Image { get; set; }
}
