using Microsoft.AspNetCore.Identity;

namespace BookApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserType{get;set;}
    }
}