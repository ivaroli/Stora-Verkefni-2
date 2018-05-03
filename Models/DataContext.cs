using Microsoft.EntityFrameworkCore;
using BookApp.Models;

namespace BookApp.Data
{
    public class DataContext : DbContext
    {
        DbSet<User> Users {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
    }
}