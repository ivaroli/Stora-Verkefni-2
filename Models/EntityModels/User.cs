using System;

namespace BookApp.Models
{
    public class User
    {
        public int ID{get; set;}
        public string UserName{get; set;}
        public string Email{get; set;}
        public string Type{get; set;}
        public string Password;
        public byte[] Image;
    }
}