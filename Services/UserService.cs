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

        //tékkar fyrst hvor user sé til og passwordin séu í lagi
        public bool SignIn(UserInputModel input)
        {
            Console.WriteLine("\nchecking for user");
            var user = userRepo.GetUserFromName(input.UserName);

            if(user == null)
            {
                return false;
            }
            else{
                string pass = GetHash(input.Password);
                Console.WriteLine("\nchecking for password");
                Console.WriteLine("\nuser pass: " + user.Password + "\n");
                Console.WriteLine("\ninserted pass: " + pass + "\n");

                if(user.Password == pass)
                {
                    return true;
                }
                return false;
            }
        }

        public bool SignUp(UserInputModel input)
        {
            Console.WriteLine("\n**1**");
            string pass = GetHash(input.Password);
            Console.WriteLine("\n**2**");
            Console.WriteLine("\nUsername: " + input.UserName + "\n");
            if(userRepo.GetUserFromName(input.UserName) != null)
            {
                Console.WriteLine("\nnot good");
                return false;
            }

            Console.WriteLine("\n**3**");

            var user = new User{UserName = input.UserName, Email = input.Email, Type="user", Password = pass};
            userRepo.CreateUser(user);
            Console.WriteLine("\n**4**");
            return true;
        }

        //Býr til sha256 hash úr string
        public string GetHash(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}