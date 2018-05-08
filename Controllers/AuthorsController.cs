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
        BookService bookService;

        public AuthorsController()
        {
            authorService = new AuthorService();
            bookService = new BookService();
            
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Console.WriteLine("ID = " + id );
            var result = bookService.GetBooksByAuthorId(id);
            Console.WriteLine("nr of books = " + result.Count);
            return View(result);
        }
        [HttpGet]
        public IActionResult Authors()
        {
            var authors = authorService.getAllAuthors();
            return View(authors);
        }

        [HttpPost]
        public IActionResult Search(string searchInput)
        {
            if(searchInput == "" || searchInput == null){

                return Json(null);
            }
            else{
                var authors = authorService.getAllAuthorsByName(searchInput);
                return Json(authors);
            }
        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorInputModel input)
        {
            authorService.AddAuthor(input);
            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveAuthor(int id)
        {
            Console.WriteLine("\n**REMOVEING AUTHOR W ID: " + id);
            authorService.RemoveAuthor(id);
            return Ok();
        }
    }
}