using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mission5.Models;

namespace mission5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AddMovieContext _AddMovieContext { get; set; }

        //contructor
        public HomeController(ILogger<HomeController> logger, AddMovieContext newMovie)
        {
            _logger = logger;
            _AddMovieContext = newMovie;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _AddMovieContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(AddMovie am)
        {
            if (ModelState.IsValid)
            {
                _AddMovieContext.Add(am);
                _AddMovieContext.SaveChanges();
                return View("Confirmation", am);
            }
            else
            {
                ViewBag.Categories = _AddMovieContext.Categories.ToList();
                return View(am);
            }



        }

        [HttpGet]
        public IActionResult MoviesList()
        {
            var currentMovies = _AddMovieContext.responses
                .Include(x => x.Category)
                .OrderBy(x => x.Category.CategoryName)
                .OrderBy(x => x.Title)
                .ToList();

            return View(currentMovies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = _AddMovieContext.Categories.ToList();

            var NewMovie = _AddMovieContext.responses.Single(x => x.MovieId == movieid);
            return View("AddMovie", NewMovie);
        }

        [HttpPost]
        public IActionResult Edit(AddMovie am)
        {
            if (ModelState.IsValid)
            {
                _AddMovieContext.Update(am);
                _AddMovieContext.SaveChanges();
                return RedirectToAction("MoviesList");
            }
            else
            {
                ViewBag.Categories = _AddMovieContext.Categories.ToList();
                return View("AddMovie", am);
            }

        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = _AddMovieContext.responses.Single(x => x.MovieId == movieid);
            return View("Delete", movie);
        }

        [HttpPost]
        public IActionResult Delete(AddMovie am)
        {
            _AddMovieContext.responses.Remove(am);
            _AddMovieContext.SaveChanges();

            return RedirectToAction("MoviesList");
        }
    }
}
