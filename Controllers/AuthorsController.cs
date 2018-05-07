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
        AuthorService authorService;

        public AuthorsController()
        {
            authorService = new AuthorService();
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string searchInput)
        {
            Console.WriteLine("\n**searching in authors: " + searchInput);
            if(searchInput == "" || searchInput == null){

                return Json(null);
            }
            else{
                var authors = authorService.getAllAuthorsByName(searchInput);
                return Json(authors);
            }
        }
    }
}