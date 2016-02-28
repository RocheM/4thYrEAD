// Lab 4 Task 1, display current date and time on a view

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RequestInfo.Controllers
{
    public class HomeController : Controller
    {
        // display the Welcome view if GET to /Home/Welcome
        [HttpGet]
        public ActionResult Welcome()
        {
            ViewBag.Message = "Date: " + DateTime.Now.ToShortDateString() + " Time: " + DateTime.Now.ToShortTimeString();
            return View();                  // i.e. Welcome.cshtml view in Home
        }
    }
}
