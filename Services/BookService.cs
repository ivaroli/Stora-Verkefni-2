using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookApp.Models;
using System.Security.Cryptography;
using System.Text;
using BookApp.Repositories;
namespace BookApp.Services
{
    public class BookService
    {
        private BookRepository _bookrepository;

        public BookService()
        {
            _bookrepository = new BookRepository();
        }
        public List<BookViewModel> GetAllBooks()
        {
            var books = _bookrepository.GetAllBooks();
            return books;
        }

        public List<BookAuthorViewModel> GetAllBooksAndAuthors()
        {
            var books = _bookrepository.GetAllBooksView();
            return books;
        }
        
        public BookViewModel GetBookById(int? id)
        {
            var book = _bookrepository.GetBookById(id);
            return book;
        }

        public List<BookViewModel> GetBooksByName(string search)
        {
            var books = _bookrepository.GetBooksByName(search);
            return books;
        }

        public List<StaffBookViewModel> GetAllBooksStaffView()
        {
            return _bookrepository.GetAllBooksStaffView();
        }

    }
}