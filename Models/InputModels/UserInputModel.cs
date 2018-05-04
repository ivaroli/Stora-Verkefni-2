using System;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class UserInputModel
    {
        public string UserName{get; set;}
        [Required]
        public string Email{get; set;}
        [Required]
        public string Password{get; set;}
    }
}