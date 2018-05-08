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
    public class HomeService
    {
        public List<BookAuthorViewModel> InitialList;
        private BookRepository bookrepository;
        private AuthorRepository authorRepository;
        private string currentTag = "Bestsellers";

        public HomeService()
        {
            bookrepository = new BookRepository();
            authorRepository = new AuthorRepository();
            InitialList = bookrepository.GetTopSellers(12);
        }

        public List<BookAuthorViewModel> search(SearchInputModel input)
        {
            if(currentTag != input.Tag){
                changeList(input.Tag);
            }

            var ret = (from c in InitialList
                        where (c.Name.Contains(input.Search) &&
                        ((c.Type == "" || c.Type == input.Genre) || input.Genre == "" || input.Genre == "All Genres")) 
                        select c).ToList();
            return ret;
        }

        private void changeList(string tag)
        {
            currentTag = tag;

            switch(tag){
                case "Books":
                    InitialList = bookrepository.GetAllBooksView();
                break;
                case "Authors":
                    InitialList = authorRepository.GetAllAuthors();
                break;
                case "Bestsellers":
                    InitialList = bookrepository.GetTopSellers(12);
                break; 
                default:
                    InitialList = bookrepository.GetAllBooksView();
                    currentTag = "Books";
                break;
            }
        }
    }
}