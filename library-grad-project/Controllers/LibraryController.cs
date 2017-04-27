using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Razor;

namespace LibraryGradProject.Controllers
{
    public class LibraryController : Controller
    {
        // GET: Library
        public ActionResult Index()
        {
            ViewBag.Title = "Library";
            return View(ViewBag);
        }
        public ActionResult Reservations()
        {
            ViewBag.Title = "reservations";
            return View();
        }
        public ActionResult ReservatinoForm()
        {
            ViewBag.Title = "Library";
            return View();
        }
    }
}