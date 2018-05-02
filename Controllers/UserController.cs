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
            return View();
        }

        //Býr til sha256 hash úr string
        public string GetHash(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
