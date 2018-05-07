using BookApp.Models;
using BookApp.Services;
using BookApp.Data;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BookApp.Repositories
{
    public class AuthorRepository
    {
        private DataContext db;
        
        public AuthorRepository()
        {
            db = new DataContext();
        }

        public List<AuthorViewModel> getAllAuthorsByName(string name)
        {
            var authors = (from a in db.Authors
                           where a.Name.Contains(name)
                           select new AuthorViewModel(){
                               Id = a.Id,
                               Name = a.Name
                           }).ToList();
            return authors;
        }
    }
}