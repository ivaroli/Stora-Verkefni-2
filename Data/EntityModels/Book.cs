using System;
namespace BookApp.Models
{
    public class Book
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Genre {get; set;}
        public Author Author {get; set;}
        public string Description {get; set;}
        public int AuthorId {get; set;}
        public string Image {get; set;}
        public int Rating {get; set;}
        public int Price {get; set;}
        public string Tag {get; set;}
    }
}