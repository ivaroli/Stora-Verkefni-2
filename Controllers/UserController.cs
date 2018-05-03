using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookApp.Models;
using BookApp.Services;

namespace BookApp.Controllers
{
    public class UserController : Controller
    {
        UserService userService = new UserService();

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(BookApp.Models.UserInputModel m)
        {
            //sign in
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(BookApp.Models.UserInputModel m)
        {
            Console.WriteLine("\nTrying to create user");
            if(userService.SignUp(m))
            {
                Console.WriteLine("\nCreated user!!!!!!");
            }
            return RedirectToAction("SignIn");
        }
    }
}
