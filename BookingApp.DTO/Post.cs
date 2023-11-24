using System.ComponentModel.DataAnnotations;

namespace BookingApp.DTO;

public class Post
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [MaxLength(50)]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Image is required")]
    public byte[]? Image { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}