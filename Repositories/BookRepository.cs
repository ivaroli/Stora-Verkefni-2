using BookApp.Models;
using BookApp.Services;
using BookApp.Data;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BookApp.Repositories
{
    public class BookRepository
    {
        private DataContext db;
        
        public BookRepository()
        {
            db = new DataContext();
        }
        public List<BookViewModel> GetAllBooks()
        {
            var books = (from a in db.Books
                        select new BookViewModel
                        {
                            Title = a.Title,
                            Genre = a.Genre,
                            Description = a.Description,
                            Author = a.Author,
                            Image = a.Image
                        }).ToList();    
            return books;
        }

        public List<BookAuthorViewModel> GetAllBooksView()
        {
            var books = (from a in db.Books
                        select new BookAuthorViewModel
                        {
                            Id = a.Id,
                            Name = a.Title,
                            Type = "Book",
                            Image = a.Image
                        }).ToList();    
            return books;
        }
    }
}