using BookingApp.DTO;
using BookingApp.Facade.Services;
using BookingApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Controllers
{
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

        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _postService.Create(post);
                return RedirectToAction("Index", "Post");
            }

            return View(post);
        }
    }
}
