using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BookApp.Models;
using System.Security.Cryptography;
using System.Text;
using BookApp.Repositories;

namespace BookApp.Services
{
    public class UserService
    {
        private UserRepository userRepo;

        public UserService()
        {
            userRepo = new UserRepository();
        }

        public void SaveUserDetails(UserDetailsInputModel model, string uId)
        {
            var repoModel = new UserDetails
            {
                UserId = uId,
                FirstName=model.FirstName,
                LastName = model.LastName,
                Country = model.Country,
                City = model.City,
                Address = model.Address,
                FavoriteBook = model.FavoriteBook
            };
            userRepo.insertUserDetaisl(repoModel);
        }

        public UserDetailsViewModel GetUserDetails(string id)
        {

            return userRepo.GetUserDetails(id);
        }
    }
}