using BookApp.Models;
using BookApp.Services;
using BookApp.Data;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BookApp.Repositories
{
    public class UserRepository
    {
        private DataContext db;

        public UserRepository()
        {
            db = new DataContext();
        }

        //Setur urserDetails í gagnasafnið
        //uesr details er td uppáhalds bók
        public void insertUserDetaisl(UserDetails userDetails)
        {
            var currentDetails = (from c in db.Details
                                  where c.UserId == userDetails.UserId 
                                  select c).FirstOrDefault();
            if(currentDetails == null)
            {
                db.Add(userDetails);
            }
            else
            {
                currentDetails.FirstName = userDetails.FirstName;
                currentDetails.LastName = userDetails.LastName;
                currentDetails.Country = userDetails.Country;
                currentDetails.City = userDetails.City;
                currentDetails.Address = userDetails.Address;
                currentDetails.FavoriteBook = userDetails.FavoriteBook;
            }

            db.SaveChanges();
        }

        //nær í user details útfrá auðkenni notanda
        public UserDetailsViewModel GetUserDetails(string userID)
        {
            var details = (from c in db.Details
                                  where c.UserId == userID 
                                  select new UserDetailsViewModel()
                                  {
                                    FirstName = c.FirstName,
                                    LastName = c.LastName,
                                    Country = c.Country,
                                    City = c.City,
                                    Address = c.Address,
                                    FavoriteBook = c.FavoriteBook
                                  }).FirstOrDefault();
            return details;
        }
    }
}