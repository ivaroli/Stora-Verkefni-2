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

        public UserDetails GetUserDetails(int userID)
        {
            return null;
        }
    }
}