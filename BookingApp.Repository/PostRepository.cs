using BookingApp.DTO;
using BookingApp.Facade.Repositories;

namespace BookingApp.Repository;

internal class PostRepository : RepositoryBase<Post>, IPostRepository
{
    public PostRepository(BookingAppDbContext context) : base(context) { }
}
