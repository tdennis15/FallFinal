using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FallFinal_2.Models;

namespace FallFinal_2.Controllers
{
    public class HomeController : Controller
    {
        MovieContext db = new MovieContext();

        public ActionResult Index()
        {
            var movie = db.Movies;
            return View(movie);
        }

       public ActionResult Movie()
        {
            var movie = db.Movies;
            return View(movie);
        }

       public ActionResult Actor()
        {
            var actor = db.Actors;
            return View(actor);
        }

       public ActionResult Cast()
        {
            var cast = db.Casts;
            return View(cast);
        }

        [HttpGet]
        public ActionResult MovieCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MovieCreate(FormCollection collection)
        {
            try
            {
                Movie movie = db.Movies.Create();

                movie.M_Name = collection["M_Name"];
                movie.M_Year = collection["M_Year"];
                movie.M_Dir = 1;

                db.Movies.Add(movie);
                db.SaveChanges();

                return RedirectToAction("Movie");
            }
            catch
            {
                return View("Movie");
            }
        }

        [HttpGet]
        public ActionResult MovieDetails(int id)
        {
            var movie = db.Movies.Where(a => a.M_ID == id).FirstOrDefault();
            return View(movie);
        }

        [HttpGet]
        public ActionResult MovieEdit(int id)
        {
            ViewBag.mName = db.Movies.Where(a => a.M_ID == id).FirstOrDefault().M_Name;
            ViewBag.mDir = db.Movies.Where(a => a.M_ID == id).FirstOrDefault().Director.D_Name;
            ViewBag.mYear = db.Movies.Where(a => a.M_ID == id).FirstOrDefault().M_Year;
            return View();
        }

        [HttpPost]
        public ActionResult MovieEdit(int id, FormCollection collection)
        {
            try
            {
                var movieToUpdate = db.Movies.Find(id);

                movieToUpdate.M_Name = collection["movieName"];
                movieToUpdate.M_Dir = 2;
                movieToUpdate.M_Year = collection["year"];
               

                db.SaveChanges();

                return RedirectToAction("MovieDetails/" + id);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult MovieDelete(int id)
        {
            var movie = db.Movies.Where(a => a.M_ID == id).FirstOrDefault();
            return View(movie);
        }

        [HttpPost]
        public ActionResult MovieDelete(int id, FormCollection collection)
        {
            try
            {
                var movie = db.Movies.Find(id);

                db.Movies.Remove(movie);
                db.SaveChanges();

                return RedirectToAction("Movie");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public JsonResult MovieResult(int? id)
        {
            //data checking for sanity
            if (id == null)
            {
                return null;
            }

            //our JSON object that will be returned
            var actors = db.Casts.Where(a => a.C_MovieID == id)
                .Select(x => x.Actor)
                .Select(x => new { x.A_Name })
                .OrderBy(x => x.A_Name)
                .ToList();

            return Json(actors, JsonRequestBehavior.AllowGet); //return the object to the CustomJS.js JavaAJAX_Call function.
        }
    }
}