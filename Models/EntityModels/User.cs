using System.Security.Cryptography;
using System.Text;
using System;

namespace BookApp.Models
{
    public class User
    {
        public int ID{get; set;}
        public string UserName{get; set;}
        public string Email{get; set;}
        public string Type{get; set;}
        public byte[] Password;
        public byte[] Image;

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