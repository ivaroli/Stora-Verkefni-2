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
        public List<Book> GetAllBooks()
        {
            var books = _bookrepository.GetAllBooks();
            return books;
        }
    }
}