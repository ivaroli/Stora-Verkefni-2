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

        public List<BookAuthorViewModel> GetTopSellers(int top)
        {
            var books = (from b in db.Books
                        join c in db.Orders on b.Id equals c.BookId into g
                        orderby g.Count() descending
                        select new BookAuthorViewModel(){
                            Id = b.Id,
                            Name = b.Title,
                            Type = "Books",
                            Image = b.Image,
                            Rating = b.Rating,
                            Price = b.Price
                        }).Take(top).ToList();

            return books;
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
                            Rating = a.Rating,
                            Price = a.Price
                        }).ToList();    
            return books;
        }

        public List<BookAuthorViewModel> GetAllBooksWTag(string Tag)
        {
            var books = (from a in db.Books
                        where a.Tag.ToLower().Contains(Tag.ToLower())
                        select new BookAuthorViewModel
                        {
                            Id = a.Id,
                            Name = a.Title,
                            Type = "Books",
                            Image = a.Image,
                            Rating = a.Rating,
                            Price = a.Price
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
                            Image = a.Image,
                            Rating = a.Rating,
                            Price = a.Price
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
                            Image = a.Image,
                            Price = a.Price
                        }).ToList();
            return books;
        }
        public BookViewModel GetBookById(int id)
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
                            Rating = a.Rating,
                            Price = a.Price
                        }).FirstOrDefault();
            return book;
        }

        public AuthorBookViewModel GetBooksByAuthorId(int? id)
        {
            var books = (from a in db.Books
                        where a.AuthorId == id
                        select new BookViewModel()
                        {
                            Id = a.Id,
                            Title = a.Title,
                            Genre = a.Genre,
                            Author = a.Author,
                            Description = a.Description,
                            Image = a.Image,
                            Rating = a.Rating,
                            Price = a.Price
                        }).ToList();
            var author = (from a in db.Authors
                          where a.Id == id
                          select new AuthorBookViewModel(){
                              Books = books,
                              Name = a.Name,
                              Image = a.Image,
                              Description = a.Description
                          }).FirstOrDefault();
            return author;
        }
        public List<BookViewModel> GetBooksByName(string search)
        {
            var books = (from a in db.Books
                        where a.Title.ToLower().Contains(search.ToLower())
                        select new BookViewModel()
                        {
                            Id = a.Id,
                            Title = a.Title,
                            Genre = a.Genre,
                            Description = a.Description,
                            Author = a.Author,
                            Image = a.Image,
                            Rating = a.Rating,
                            Price = a.Price
                        }).ToList();
            return books;
        }

        public void RemoveBooksByAuthor(int AuthorId)
        {
            var books = (from a in db.Books
                        where a.AuthorId == AuthorId
                        select a).ToList();
            db.RemoveRange(books);
            db.SaveChanges();
        }

        public void addBook(Book b)
        {
            db.Add(b);
            db.SaveChanges();
        }

        public void removeBook(int id)
        {
            var bookToRemove = (from c in db.Books
                                where c.Id == id
                                select c).FirstOrDefault();
            db.Books.Remove(bookToRemove);
            db.SaveChanges();
        }
    }
}