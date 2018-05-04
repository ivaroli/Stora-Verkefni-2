using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using BookApp.Data;
using BookApp.Models;

namespace BookApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            seedData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        
        public static void seedData()
        {
            /*var db = new DataContext();

            if(!db.Users.Any())
            {
                var initailUsers = new List<User>()
                {
                    new User{UserName = "ivaroli", Email="ivartheoli@gmail.com", Type="staff", Password="b4d2c4697bdd9b3bc4746535416e0d2d93a4cd043847afb68c738609d92948b2"}
                };

                db.AddRange(initailUsers);
                db.SaveChanges();
            }*/
        }
    }
}
