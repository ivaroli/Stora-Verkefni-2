using Microsoft.EntityFrameworkCore;
using BookApp.Models;

namespace BookApp.Data
{
    public class DataContext : DbContext
    {
        DbSet<User> Users {get; set;}
        DbSet<User> Books {get; set;}
        DbSet<User> Authors {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H09;Persist Security Info=False;User ID=VLN2_2018_H09_usr;Password=$weetJoke36;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}