using System;

namespace BookApp.Models
{
    public class Review
    {
         public int Id{get; set;}
         public int BookId { get; set; }
         public int Stars { get; set; }
        public string UserId{get;set;}
        public string CommentText{get;set;}
        public DateTime time{get;set;}
        
    }
}