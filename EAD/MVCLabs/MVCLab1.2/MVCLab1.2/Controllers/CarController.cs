using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCLab1._2.Models;

namespace MVCLab1._2.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        [HttpGet]
        public ActionResult Car()
        {
            Models.Car toReturn = new Car() { make = "Mazda", model = "Model200", engineType = engineType.diesel, enineSize = 2.2 };

            return View(toReturn);
        }
    }
}