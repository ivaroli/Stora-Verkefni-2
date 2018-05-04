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
    public class AuthorsController : Controller
    {
        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }
    }
}