using System.Web;

namespace BookApp.Models
{
    public class UserDetailsInputModel
    {
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public string Country{get; set;}
        public string City{get; set;}
        public string Address{get; set;}

        //public HttpPostedFilesBase Image { get; set; }
    }
}