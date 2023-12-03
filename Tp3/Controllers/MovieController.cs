using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tp3.Models;
using Tp3.Repositories;
using Tp3.Services.ServiceContracts;

namespace Tp3.Controllers
{
    public class MovieController : Controller
    {
        public readonly IMovieService _movieService;

        public readonly MovieRepository _movieRepository;


        public MovieController(IMovieService movieService, MovieRepository movieRepository)
        {
            // _appDbContext = appDbContext;
            _movieService = movieService;
            _movieRepository = movieRepository;

        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            //var movie = _db.movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
            var movie = _movieRepository.GetMovieById(id);
            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Movie c)
        {
            ViewBag.errors = ModelState.Values
           .SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (c.PictureFile != null)
            {
                var fileName = Path.GetFileName(c.PictureFile.FileName);
                var filePath = Path.Combine("D:/GL3/sem1/frameworks de dev/tpTp3/Tp3/wwwroot/", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await c.PictureFile.CopyToAsync(stream);
                }
                c.PictureURL = "/" + fileName;
            }

            _movieRepository.CreateMovie(c);

            return RedirectToAction(nameof(Index));
        }
    }
}
