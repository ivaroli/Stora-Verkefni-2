using System;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class UserInputModel
    {
        [Required]
        public string UserName{get; set;}
        public string Email{get; set;}
        [Required]
        public string Password{get; set;}
    }
}