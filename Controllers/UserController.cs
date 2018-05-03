using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookApp.Models;
using System.Security.Cryptography;
using System.Text;

namespace BookApp.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(BookApp.Models.UserInputModel m)
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(BookApp.Models.UserInputModel m)
        {
            return RedirectToAction("SignIn");
        }
    }
}
