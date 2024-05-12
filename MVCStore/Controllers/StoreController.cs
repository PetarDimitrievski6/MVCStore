using MVCStore.Models;
using MVCStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStore.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        /*public string Index()
        {
            return "Hello from Store.Index()";
        }*/


        public ActionResult Index()
        {
            return View();
        }
        public string Browse()
        {
            return "Hello from Store.Browse()";
        }

        [Route("store/details/{artistid:range(1,5)}/{artistalbum:regex(\\w*\\d(4))}")]
        public string Details(int? artistid, string artistalbum)
        {
            return "Hello from Store.Details(), ID = " + artistid + "Album = " + artistalbum;
        }
        public ActionResult List()
        {
            Artist artist = new Artist { Name = "Some famous" };
            var albums = new List<Album>();
            for (int i = 0; i < 10; i++)
            {
                albums.Add(new Album
                {
                    Title = "AlbumTitle" + i.ToString(),
                });
            }
            //ViewBag.Albums = albums;

            var viewModel = new ArtistAlbumsViewModel
            {
                Artist = artist,
                Albums = albums
            };

            return View(viewModel);
        }
        public ActionResult ShowSearch()
        {
            return View();
        }
        public ActionResult Search(string q) {
            var albums = new List<Album>();
            albums.Add(new Album { Title = "Experience" });
            albums.Add(new Album { Title = "Music for the Jilted Generation" });
            albums.Add(new Album { Title = "The Fat of the Land" });
            albums.Add(new Album { Title = "Always Outnumbered, Never Outgunned" });
            albums.Add(new Album { Title = "Invaders Must Die" });
            albums.Add(new Album { Title = "The Day Is My Enemy" });
            
            var resultAlbums = new List<Album>();
            foreach (Album a in albums)
            {
                if (a.Title.Contains(q))
                {
                    resultAlbums.Add(a);
                }
            }

            return View(resultAlbums);
        }
        public ActionResult Helper1()
        {
            return View();
        }
        public ActionResult Helper1V(string myTextBox)
        {
            return Content("TextBox = " + myTextBox);
        }
    }
}