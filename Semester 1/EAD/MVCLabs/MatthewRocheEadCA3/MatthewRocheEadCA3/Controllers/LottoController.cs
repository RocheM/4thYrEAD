//Matthew Roche EAD CA3
//http://matthewrocheeadca3.azurewebsites.net/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatthewRocheEadCA3.Controllers
{
    public class LottoController : Controller
    {
        [HttpGet]
        public ActionResult Lotto()
        {
            // no data displayed initially
            return View();
        }

        // process data, show results
        [HttpPost]
        public ActionResult Lotto(Models.Lotto results)
        {
            

            if (ModelState.IsValid)
            {
                results.generateNumbers(results.maxNumber, results.numbersToDraw);
                return View(results);
            }
            else
            {
                return View();
            }
 

        }
    }
}