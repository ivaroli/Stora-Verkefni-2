using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookApp.Models;
using BookApp.Services;
using Microsoft.AspNetCore.Identity;

namespace BookApp.Controllers
{
    public class UserController : Controller
    {
        private UserService userService = new UserService();
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public IActionResult StaffPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(BookApp.Models.UserInputModel m)
        {
            if(userService.SignIn(m))
            {
                Console.WriteLine("\nSigned In!!!!");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(BookApp.Models.UserInputModel m)
        {
            /*Console.WriteLine("\nTrying to create user");
            if(userService.SignUp(m))
            {
                Console.WriteLine("\nCreated user!!!!!!");
            }
            return RedirectToAction("SignIn");*/
            return RedirectToAction("SignIn");
        }
    }
}
