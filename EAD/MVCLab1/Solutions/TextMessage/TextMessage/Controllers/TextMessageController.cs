using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TextMessage.Models;

namespace TextMessage.Controllers
{
    public class TextMessageController : Controller
    {
        //
        // GET: /TextMessage/Send

        [HttpGet]
        public ActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(SMSMessage smsMessage)
        {
            if (ModelState.IsValid)
            {
                // move to confirm screen
                return RedirectToAction("Confirm", smsMessage);
                
            }
            else
            {   // invalid data
                return View();
            }
        }

       
        // display a confirmation 
        public ActionResult Confirm(SMSMessage smsMessage)
        {
            return View(smsMessage);
        }

       
    }
}
