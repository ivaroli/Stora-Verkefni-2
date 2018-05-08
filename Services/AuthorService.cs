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
    public class AuthorService
    {
        private AuthorRepository authorRepository;
        private BookService bookService;

        public AuthorService()
        {
            authorRepository = new AuthorRepository();
            bookService = new BookService();
        }

        public List<AuthorViewModel> getAllAuthorsByName(string name)
        {
            return authorRepository.getAllAuthorsByName(name);
        }

        public void AddAuthor(AuthorInputModel model)
        {
            var author = new Author(){
                Name = model.Name,
                Description = model.Description,
                Image = model.Image
            };

            authorRepository.AddAuthor(author);
        }

        public void RemoveAuthor(int id)
        {
            bookService.RemoveBooksByAuthor(id);
            authorRepository.RemoveAuthor(id);
            Console.WriteLine("\nREMOVED AUTHOR");
        }
    }
}