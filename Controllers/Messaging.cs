using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace  mazitye.Controllers
{
 
    public class MessagingController: Controller
    {
        public IActionResult Messaging()
        {
            return View();
        }
    }
}