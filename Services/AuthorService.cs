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

        public AuthorService()
        {
            authorRepository = new AuthorRepository();
        }

        public List<AuthorViewModel> getAllAuthorsByName(string name)
        {
            return authorRepository.getAllAuthorsByName(name);
        }
    }
}