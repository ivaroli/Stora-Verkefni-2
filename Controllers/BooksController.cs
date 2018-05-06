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
    public class BooksController : Controller
    {
         private BookService _bookService;
        public BooksController()
        {
            _bookService = new BookService();
        }

        [HttpGet]
        public IActionResult Details()
        {
            //var books = _bookService.GetAllBooks();
            //return View(books);
            return View();
        }
        [HttpGet]
        public IActionResult Books()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }
    }
}