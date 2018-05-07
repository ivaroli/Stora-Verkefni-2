using System;
namespace BookApp.Models
{
    public class BookViewModel
    {
        public int Id{get; set;}
        public string Title{get; set;}
        public string Genre{get; set;}
        public Author Author{get; set;}
        public string Description{get; set;}
        public string Image{get; set;}
    }
}