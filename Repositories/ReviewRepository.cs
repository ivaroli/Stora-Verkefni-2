using BookApp.Models;
using BookApp.Services;
using BookApp.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace BookApp.Repositories
{
     
    public class ReviewRepository
    {
        private Data.DataContext db;
        
        public ReviewRepository()
        {
            db = new DataContext();
        }

        //Nær í öll komment á bók útfá auðkenni hennar
        public List<ReviewViewModel> GetReviewsByBookId(int id)
        {
            var book = (from a in db.Reviews
                        where a.BookId == id
                        select new ReviewViewModel()
                        {
                            Id = a.Id,
                            BookId = a.BookId,
                            Stars = a.Stars,
                            CommentText = a.CommentText,
                            User = a.UserName,
                            time = a.time
                        });
            return book.ToList();
        }

        //bætir kommenti hjá bók
        public void AddReview(ReviewInputModel r)
        {
            var review = new Review
            {
                BookId = r.BookId,
                CommentText = r.CommentText,
                Stars = r.Stars,
                UserId = r.UserId,
                UserName = r.UserName,
                time = DateTime.Now
            };
            db.Add(review);
            db.SaveChanges();
        }
    }
}