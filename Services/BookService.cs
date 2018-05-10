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
        private BookRepository bookrepository;
        private AuthorRepository authorRepository;

        public BookService()
        {
            bookrepository = new BookRepository();
            authorRepository = new AuthorRepository();
        }
        public List<BookViewModel> GetAllBooks()
        {
            var books = bookrepository.GetAllBooks();
            return books;
        }

        public List<BookAuthorViewModel> GetAllBooksAndAuthors()
        {
            var books = bookrepository.GetAllBooksView();
            return books;
        }
        
        public BookViewModel GetBookById(int id)
        {
            var book = bookrepository.GetBookById(id);
            return book;
        }

         public AuthorBookViewModel GetBooksByAuthorId(int? id)
        {
            var book = bookrepository.GetBooksByAuthorId(id);
            return book;
        }

        public List<BookViewModel> GetBooksByName(string search)
        {
            var books = bookrepository.GetBooksByName(search);
            return books;
        }

        public List<StaffBookViewModel> GetAllBooksStaffView()
        {
            return bookrepository.GetAllBooksStaffView();
        }

        public void AddBook(BookInputModel model)
        {
            var author = authorRepository.getAuthorFromId(model.AuthorId);
            var book = new Book(){
                Title = model.Title,
                Genre = model.Genre,
                Description = model.Description,
                AuthorId = model.AuthorId,
                Rating = model.Rating,
                Image = model.Image,
                Price = model.Price,
                Tag = model.Tag
            };
            bookrepository.addBook(book);
        }

        public void removeBook(int id)
        {
            bookrepository.removeBook(id);
        }

        public void RemoveBooksByAuthor(int id)
        {
            bookrepository.RemoveBooksByAuthor(id);
        }

        public List<BookAuthorViewModel> GetTopBooks()
        {
            return bookrepository.GetTopSellers(12);
        }
    }
}