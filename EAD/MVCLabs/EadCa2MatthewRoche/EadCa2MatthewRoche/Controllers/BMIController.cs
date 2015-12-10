using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Matthew Roche X00102929

namespace EadCa2MatthewRoche.Controllers
{
    public class BMIController : Controller
    {
      
        public ActionResult BMICalculator()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult BMICalculator(Models.BMI person)
        {
            if (ModelState.IsValid)
            {
                person.calculateBMI();
                return RedirectToAction("Results", person);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Results(Models.BMI person)
        {

            return View(person);
        }

    }
}

