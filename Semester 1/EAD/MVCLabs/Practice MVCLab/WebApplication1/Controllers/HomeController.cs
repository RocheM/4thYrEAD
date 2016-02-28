using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Person()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Person(Models.Person person)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ConfirmPerson", person);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ConfirmPerson(Models.Person person)
        {

            return View(person);

        }
    }
}