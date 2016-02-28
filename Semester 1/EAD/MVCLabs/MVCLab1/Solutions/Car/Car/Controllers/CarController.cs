using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Car.Models;                   // model namespace

namespace Car.Controllers
{
    public class CarController : Controller
    {
        
        // GET: ../Car/Display
        [HttpGet]
        public ActionResult Display()
        {
            Car.Models.Car car = new Car.Models.Car() { Make = "Mazda", Model = "6", EngineType = CarEngineType.Petrol, EngineSize = 1800 };
            return View(car);
        }
    }
}
