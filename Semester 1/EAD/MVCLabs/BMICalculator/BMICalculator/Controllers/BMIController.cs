// Controller for BMI calculator
// GC

using BMICalculator.Models;
using System.Web.Mvc;

namespace BMICalculator.Controllers
{
    public class BMIController : Controller
    {
        // /BMI/Calculate
        [HttpGet]
        public ActionResult Calculate()
        {
            // no data displayed initially
            return View();
        }

        // process data, display BMI value and BMI category
        [HttpPost]
        public ActionResult Calculate(BMI bmi)
        {
            return View(bmi);  
        }
    }
}