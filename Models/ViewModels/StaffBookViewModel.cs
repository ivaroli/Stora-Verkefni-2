using System;
namespace BookApp.Models
{
    public class StaffBookViewModel
    {
        public int Id { get; set; }
        public string Title{get; set;}
        public string Genre{get; set;}
        public int AuthorId{get; set;}
        public string Description{get; set;}
        public string Image{get; set;}
    }
}