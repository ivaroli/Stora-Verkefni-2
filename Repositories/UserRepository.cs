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

        public User GetUserFromName(string userName)
        {
            var user = (from a in db.Users
                        where a.UserName == userName
                        select a).FirstOrDefault();
            return user;
        }

        public void CreateUser(User user)
        {
            db.Add(user);
            db.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            var users = (from a in db.Users
                        select a).ToList();
            return users;
        }
    }
}