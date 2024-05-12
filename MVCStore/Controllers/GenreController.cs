using MVCStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStore.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre
        /*static List<Genre> genreList = new List<Genre> {
            new Genre(){GenreId = 1, Name = "Rock"},
            new Genre(){ GenreId = 2, Name = "Jazz"}
        };*/
        public ApplicationDbContext _context;

        public GenreController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);    
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var genreList = _context.Genres.ToList();
            return View(genreList);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult CreateNew(Genre genre)
        {
            //genreList.Add(genre);
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return RedirectToAction("Index", "Genre");
        }
        public ActionResult Delete(int id)
        {
            /*foreach (Genre genre in genreList.ToList())
            {
                if (genre.GenreId == id)
                {
                    genreList.Remove(genre);
                }
            }*/
            Genre g = _context.Genres.Find(id);
            _context.Genres.Remove(g);
            _context.SaveChanges();
            return RedirectToAction("Index", "Genre");
        }
        public ActionResult Edit(int id)
        {
            /*var genre = new Genre() { GenreId = 0 };
            foreach (Genre g in genreList)
            {
                if (g.GenreId == id)
                {
                    genre = g;
                }
            }
            if(genre.GenreId == 0)
            {
                return HttpNotFound();
            }*/

            var genre = _context.Genres.Single(g => g.GenreId == id);

            if (genre == null)
            {
                return HttpNotFound();
            }

            return View(genre);
        }
        public ActionResult EditGenre(Genre genre)
        {
            /*foreach (Genre g in genreList)
            {
                if (g.GenreId == genre.GenreId)
                {
                    g.Name = genre.Name;
                }
            }*/

            var genreInDb = _context.Genres.Single(g => g.GenreId == genre.GenreId);
            TryUpdateModel(genreInDb);
            _context.SaveChanges();
            return RedirectToAction("Index", "Genre");
        }
    }
}