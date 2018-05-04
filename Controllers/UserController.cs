using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
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
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(BookApp.Models.UserInputModel model)
        {
            if(!ModelState.IsValid)
            {
                Console.WriteLine("\n**Vesen**");
                return RedirectToAction("SignIn");
            }
            var user = new ApplicationUser {UserName = model.UserName, Email = model.Email};
            var result = await userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                await userManager.AddClaimAsync(user, new Claim("UserName", $"{model.UserName}"));
                await signInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Home");
            }
            Console.WriteLine("\n**Ekki Eins Mikid Vesen**");
            return RedirectToAction("SignIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(BookApp.Models.UserInputModel model)
        {
            if(!ModelState.IsValid)
            {
                Console.WriteLine("\n**Vesen**");
                return RedirectToAction("SignIn");
            }
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);

            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("SignIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public IActionResult StaffPage()
        {
            return View();//asdf
        }
    }
}
