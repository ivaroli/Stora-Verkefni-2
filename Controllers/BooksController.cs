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
        }
        [HttpGet]
        public IActionResult Books()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }

        [HttpPost]
        public IActionResult Search(string searchInput)
        {
            if(searchInput == "" || searchInput == null){
                Console.WriteLine("\n**ASDFASDFASDF");
                var books = _bookService.GetAllBooks();
                return Json(books);
            }
            else{
                var books = _bookService.GetBooksByName(searchInput);
                return Json(books);
            }
        }
    }
}