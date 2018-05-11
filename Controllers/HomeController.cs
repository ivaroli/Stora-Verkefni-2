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
    public class HomeController : Controller
    {
        private HomeService homeService;

        public HomeController()
        {
            homeService = new HomeService();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(homeService.InitialList);
        }

        [HttpPost]
        public IActionResult Search(SearchInputModel input)
        {
            Console.WriteLine("\n**GENRE: " + input.Genre);
            return Json(homeService.search(input));
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Help()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
