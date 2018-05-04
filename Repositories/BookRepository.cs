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
        public List<Book> GetAllBooks()
        {
            var books = (from a in db.Books
                        select new Book
                        {
                            Id = a.Id,
                            Title = a.Title,
                            Genre = a.Genre,
                            Description = a.Description,
                            AuthorId = a.AuthorId,
                            Image = a.Image
                        }).ToList();    
            return books;
        }
    }
}