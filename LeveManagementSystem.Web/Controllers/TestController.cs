﻿using LeveManagementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeveManagementSystem.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var data = new TestViewModel
            {
                Name = "Student",
                DateOfBirth = new DateTime(1954, 12, 01)

            };
            

            return View(data);
        }
    }
}
