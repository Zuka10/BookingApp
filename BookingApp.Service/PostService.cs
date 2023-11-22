using BookingApp.DTO;
using BookingApp.Facade.Repositories;
using BookingApp.Facade.Services;

namespace BookingApp.Service;

public class PostService : IPostService
{
    private IUnitOfWork _unitOfWork;

    public PostService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(Post post)
    {
        _unitOfWork.PostRepository.Insert(post);
        _unitOfWork.SaveChanges();
    }

    public void Update(Post post)
    {
        var existingPost = _unitOfWork.PostRepository.Get(post.Id);
        existingPost.Title = post.Title;
        existingPost.Description = post.Description;
        existingPost.Image = post.Image;
        _unitOfWork.PostRepository.Update(existingPost);
        _unitOfWork.SaveChanges();
    }

    public void Delete(Post post)
    {
        var existingPost = _unitOfWork.PostRepository.Get(post.Id);
        if (existingPost != null)
        {
            _unitOfWork.PostRepository.Delete(post);
            _unitOfWork.SaveChanges();
        }
    }

    public IEnumerable<Post> GetAll()
    {
        var posts = _unitOfWork.PostRepository.GetAll();
        return posts;
    }

    public Post GetById(int id)
    {
        var post = _unitOfWork.PostRepository.Get(id);
        _unitOfWork.SaveChanges();
        return post;
    }

}
