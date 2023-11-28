using BookingApp.DTO;
using BookingApp.Facade.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Controllers;

public class PostController : Controller
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    public IActionResult Index()
    {
        var posts = _postService.GetAll();
        return View(posts);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Post post, IFormFile image)
    {
        if (image != null && image.Length > 0)
        {
            using (var ms = new MemoryStream())
            {
                image.CopyTo(ms);
                post.Image = ms.ToArray();
            }
        }
        _postService.Create(post);

        return RedirectToAction("Index", "Post");
    }

    public IActionResult Edit(int id)
    {
        var post = _postService.GetById(id);

        if (post == null)
        {
            return NotFound();
        }

        return View(post);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Post post, IFormFile newImage)
    {
        if (id != post.Id)
        {
            return NotFound();
        }

        // Retrieve the existing post from the database
        var existingPost = _postService.GetById(id);

        if (existingPost == null)
        {
            return NotFound();
        }

        // Update properties other than Image
        existingPost.Title = post.Title;
        existingPost.Description = post.Description;

        // Check if a new image is provided
        if (newImage != null && newImage.Length > 0)
        {
            using (var ms = new MemoryStream())
            {
                newImage.CopyTo(ms);
                existingPost.Image = ms.ToArray();
            }
        }

        // Update the post in the database
        _postService.Update(existingPost);

        return RedirectToAction("Index", "Post");
    }

    public IActionResult Delete(int id)
    {
        var post = _postService.GetById(id);

        if (post == null)
        {
            return NotFound();
        }

        return View(post);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var post = _postService.GetById(id);

        if (post != null)
        {
            _postService.Delete(post);
        }

        return RedirectToAction("Index", "Post");
    }

    public IActionResult Details(int id)
    {
        var post = _postService.GetById(id);

        if (post == null)
        {
            return NotFound();
        }

        return View(post);
    }
}
