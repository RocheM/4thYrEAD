// controller for LPT calculator

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LPT.Models;

namespace LPT.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Calculate()
        {
            return View();
        }

        // just 1 view

        [HttpPost]
        public ActionResult Calculate(LocalPropertyTax lpt)
        {
            return View(lpt);
        }
    }
}
