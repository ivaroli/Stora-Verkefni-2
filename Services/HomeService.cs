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
            if(currentTag != input.Tag)
            {
                changeList(input.Tag);
            }

            if(input.Search != null && input.Search != "")
            {
                var ret = (from c in InitialList
                        where (c.Name.ToLower().Contains(input.Search.ToLower()) &&
                        ((c.Genre == "" || c.Genre == input.Genre) || input.Genre == "" || input.Genre == "All Genres")) 
                        select c).ToList();
                return ret;
            }
            else
            {
                if(input.Tag != "Authors")
                {
                    Console.WriteLine("ASDF");
                    var ret = (from c in InitialList
                           where ((c.Genre == "" || c.Genre.ToLower().Contains(input.Genre.ToLower())) || input.Genre == "" || input.Genre == "All Genres")
                           select c).ToList();
                    return ret;
                }
                else
                {
                    return InitialList;
                }
            }
        }

        private void changeList(string tag)
        {
            currentTag = tag;

            switch(tag)
            {
                case "Books":
                    InitialList = bookrepository.GetAllBooksView();
                break;
                case "Authors":
                    InitialList = authorRepository.GetAllAuthors();
                break;
                case "Bestsellers":
                    InitialList = bookrepository.GetTopSellers(12);
                    break; 
                case "Coming Soon":
                    InitialList = bookrepository.GetAllBooksWTag(tag);
                    break;
                case "E-Books":
                    InitialList = bookrepository.GetAllBooksWTag(tag);
                    break;
                case "Second Hand":
                    InitialList = bookrepository.GetAllBooksWTag(tag);
                    break;
                case "Just Arrived":
                    InitialList = bookrepository.GetAllBooksWTag(tag);
                    break;
                case "Classics":
                    InitialList = bookrepository.GetAllBooksWTag(tag);
                    break;
                case "Book Series":
                    InitialList = bookrepository.GetAllBooksWTag(tag);
                    break;
                default:
                    InitialList = bookrepository.GetAllBooksView();
                    currentTag = "Books";
                break;
            }
        }
    }
}