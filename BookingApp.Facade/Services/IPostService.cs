using BookingApp.DTO;

namespace BookingApp.Facade.Services;

public interface IPostService
{
    void Create(Post post);
    void Update(Post post);
    void Delete(Post post);
    Post GetById(int id);
    IEnumerable<Post> GetAll();
}
