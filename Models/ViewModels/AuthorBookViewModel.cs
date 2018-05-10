using System;
using System.Collections.Generic;
namespace BookApp.Models
{
    public class AuthorBookViewModel
    {
        public List<BookViewModel> Books { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}