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
        private AuthorRepository authorRepository;

        public BookService()
        {
            _bookrepository = new BookRepository();
            authorRepository = new AuthorRepository();
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

        public void AddBook(BookInputModel model)
        {
            var author = authorRepository.getAuthorFromId(model.AuthorId);
            var book = new Book(){
                Title = model.Title,
                Genre = model.Genre,
                //Author = author,
                Description = model.Description,
                AuthorId = model.AuthorId,
                Rating = model.Rating
            };
            _bookrepository.addBook(book);
        }
    }
}