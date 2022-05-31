using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace  mazitye.Controllers
{
 
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult About()
        {
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }
    }
}