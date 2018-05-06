using System;
namespace BookApp.Models
//namespace BookApp.Models.EntityModels
{
    public class Book
    {
        public int Id{get; set;}
        public string Title{get; set;}
        public string Genre{get; set;}
        public string Author{get; set;}
        public string Description{get; set;}
        public int AuthorId{get; set;}
        public byte[] Image;
    }
}