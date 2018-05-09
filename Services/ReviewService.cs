using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookApp.Models;
using System.Security.Cryptography;
using System.Text;
using BookApp.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace BookApp.Services
{
    public class ReviewService
    {
         private ReviewRepository _reviewRepository;
        public ReviewService()
        {
            _reviewRepository = new ReviewRepository();
        }

        public List<ReviewViewModel> GetReviewsByBookId(int id)
        {
            var reviews = _reviewRepository.GetReviewsByBookId(id);
            return reviews;
        }

        public void AddReview(ReviewInputModel review)
        {
            _reviewRepository.AddReview(review);
        }
    }
}