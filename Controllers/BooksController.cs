using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookApp.Models;
using BookApp.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace BookApp.Controllers
{
    public class BooksController : Controller
    {
         private BookService bookService;
         private AuthorService authorService;
         private ReviewService reviewService;
        public BooksController()
        {
            bookService = new BookService();
            authorService = new AuthorService();
            reviewService = new ReviewService();
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index","Home");
            }

            int id_not_null = id ?? default(int);
            var book = bookService.GetBookById(id_not_null);
            if(book == null)
            {
                return RedirectToAction("Index","Home");
            }
            return View(book);
        }
        [HttpGet]
        public IActionResult Books()
        {
            var books = bookService.GetAllBooks();
            return View(books);
        }

        [HttpPost]
        public IActionResult Search(string searchInput)
        {
            if(searchInput == "" || searchInput == null){
                Console.WriteLine("\n**ASDFASDFASDF");
                var books = bookService.GetAllBooks();
                return Json(books);
            }
            else{
                var books = bookService.GetBooksByName(searchInput);
                return Json(books);
            }
        }

        [HttpPost]
        public IActionResult AddBook(BookInputModel input)
        {
            Console.WriteLine("\n**TYPPI ADF BOOK: " + input.Image);
            bookService.AddBook(input);
            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveBook(int id)
        {
            Console.WriteLine("\n**Removing book with id: " + id);
            bookService.removeBook(id);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddReview(int rating, string comment, int bookId)
        {
            var uId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            DateTime date = DateTime.Now;

            var model = new ReviewInputModel(){
                BookId = bookId,
                Stars = rating,
                UserId = uId,
                UserName = User.FindFirst(ClaimTypes.Name).Value,
                CommentText = comment,
                time = date
            };

            reviewService.AddReview(model);
            return Ok();
        }

        [HttpPost]
        public IActionResult GetReviews(int bookId)
        {
            var reviews = reviewService.GetReviewsByBookId(bookId);
            return Json(reviews);
        }
    }
}