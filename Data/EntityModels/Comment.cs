using System;
namespace BookApp.Models
{
    public class Comment
    {
        public int Id{get; set;}
        public string UserId{get;set;}
        public string CommentText{get;set;}
        public DateTime time{get;set;}
    }
}