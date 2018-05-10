using System;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class BookAuthorViewModel
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public string Type{get; set;}
        public string Image{get; set;}
        public int Rating {get; set; }
        public int Price {get; set; }
    }
}