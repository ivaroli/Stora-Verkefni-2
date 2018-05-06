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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace BookApp.Controllers
{
    public class UserController : Controller
    {
        private UserService userService = new UserService();
        private BookService booksService = new BookService();
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
            if(!ModelState.IsValid || model.Email == "")
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
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);
            Console.WriteLine("\nEmail: " + model.Email + "\nPassword: " + model.Password + "\nUsername: " + model.UserName);

            if(result.Succeeded)
            {
                Console.WriteLine("\n**ASDF**");
                return RedirectToAction("Index", "Home");
            }
            Console.WriteLine("\n**TYPPI**");
            return RedirectToAction("SignIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Details(UserDetailsViewModel model)
        {
            var details = userService.GetUserDetails(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(details);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Details(UserDetailsInputModel model)
        {
            userService.SaveUserDetails(model, this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok();
        }

        [HttpGet]
        public IActionResult StaffPage()
        {
            return View();//asdf
        }
    }
}
