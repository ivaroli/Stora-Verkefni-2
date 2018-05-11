using System;

namespace BookApp.Models
{
    public class UserDetails
    {
        public int Id {get; set;}
        public string UserId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Country {get; set;}
        public string City {get; set;}
        public string Address {get; set;}
        public string FavoriteBook {get; set;}
        public byte[] Image {get; set;}
    }
}