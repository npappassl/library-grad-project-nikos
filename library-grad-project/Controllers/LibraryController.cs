using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryGradProject.Controllers
{
    public class LibraryController : Controller
    {
        // GET: Library
        public ActionResult Index()
        {
            ViewBag.Title = "Library";
            return View();
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