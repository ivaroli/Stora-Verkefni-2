using Microsoft.AspNetCore.Http;

namespace BookApp.Models
{
    public class UserDetailsViewModel
    {
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public string Country{get; set;}
        public string City{get; set;}
        public string Address{get; set;}
        public string FavoriteBook{get; set;}
    }
}