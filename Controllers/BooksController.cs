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
<<<<<<< HEAD
        public IActionResult Details(int ?id)
        {
            //var books = _bookService.GetAllBooks();
            //return View(books);
            
            return View();
=======
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index","Home");
            }
            var book = _bookService.GetBookById(id);
            if(book == null)
            {
                return RedirectToAction("Index","Home");
            }
            return View(book);
>>>>>>> db78c2e1502e685211211bbbfb1c9f1e5be61077
        }
        [HttpGet]
        public IActionResult Books()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }
    }
}