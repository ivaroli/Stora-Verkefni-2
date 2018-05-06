using System;
namespace BookApp.Models
//namespace BookApp.Models.EntityModels
{
    public class BookViewModel
    {
        public string Title{get; set;}
        public string Genre{get; set;}
        public Author Author{get; set;}
        public string Description{get; set;}
        public string Image{get; set;}
    }
}