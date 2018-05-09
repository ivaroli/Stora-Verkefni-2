using System;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class BookOrderViewModel
    {
        public string Title{get; set;}
        public int Price{get; set;}
        public string Author{get; set;}
        public string Image{get; set;}
    }
}