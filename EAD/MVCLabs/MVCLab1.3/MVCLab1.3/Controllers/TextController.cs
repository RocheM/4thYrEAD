using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCLab1._3.Models;

namespace MVCLab1._3.Controllers
{
    public class TextController : Controller
    {
        // GET: Text
        [HttpGet]
        public ActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(Text message)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Confirm", message);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Confirm(Text Message)
        {
            return View(Message);
        }


    }
}