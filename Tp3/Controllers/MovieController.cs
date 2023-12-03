using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tp3.Models;

namespace Tp3.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var movies = _db.movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

       /* public IActionResult Create()
        {
            ViewBag.Genres = new SelectList(_db.genres, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                
                _db.movies.Add(movie);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Genres = new SelectList(_db.genres, "Id", "Name");
            return View(movie);

        }*/
    }
}
