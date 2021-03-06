﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCLab1.Controllers
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

       public ActionResult Car()
        {

            Models.Car c = new Models.Car();

            c.Make = "Test";


            return View();
        }

        public ActionResult Date()
        {
            DateTime now = DateTime.Now;
            ViewBag.Message = now.ToString();
            ViewBag.timezone = TimeZone.CurrentTimeZone.StandardName;
            
            return View();
        }
    }
}