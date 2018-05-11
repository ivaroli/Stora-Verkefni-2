using System;

namespace BookApp.Models
{
    public class ReviewInputModel
    {
        public int BookId {get; set;}
        public int Stars {get; set;}
        public string UserId {get; set;}
        public string UserName {get; set;}
        public string CommentText {get; set;}
        public DateTime time {get; set;}
        
    }
}