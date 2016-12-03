using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Bike Store Application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Simon Chettleburgh.";

            return View();
        }
    }
}