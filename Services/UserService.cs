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

namespace BookApp.Services
{
    public class UserService
    {
        private UserRepository userRepo;

         public UserService()
         {
             userRepo = new UserRepository();
         }
    }
}