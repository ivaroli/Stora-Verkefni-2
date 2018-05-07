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
                            Id = a.Id,
                            Title = a.Title,
                            Genre = a.Genre,
                            Description = a.Description,
                            Author = a.Author,
                            Image = a.Image,
                            Rating = a.Rating
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

        public List<StaffBookViewModel> GetAllBooksStaffView()
        {
            var books = (from a in db.Books
                        select new StaffBookViewModel
                        {
                            Id = a.Id,
                            Title = a.Title,
                            Genre = a.Genre,
                            AuthorId = a.AuthorId,
                            Description = a.Description,
                            Image = a.Image
                        }).ToList();
            return books;
        }
        public BookViewModel GetBookById(int? id)
        {
            var book = (from a in db.Books
                        where a.Id == id
                        select new BookViewModel()
                        {
                            Id = a.Id,
                            Title = a.Title,
                            Genre = a.Genre,
                            Description = a.Description,
                            Author = a.Author,
                            Image = a.Image,
                            Rating = a.Rating
                        }).FirstOrDefault();
            return book;
        }

        public List<BookViewModel> GetBooksByName(string search)
        {
            var books = (from a in db.Books
                        where a.Title.Contains(search)
                        select new BookViewModel()
                        {
                            Title = a.Title,
                            Genre = a.Genre,
                            Description = a.Description,
                            Author = a.Author,
                            Image = a.Image,
                            Rating = a.Rating
                        }).ToList();
            return books;
        }

        public void addBook(Book b)
        {
            db.Add(b);
            db.SaveChanges();
        }
    }
}