using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore2207.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookStore2207.data
{
    public class BookContext: IdentityDbContext<Applicationuser>
    {
        IConfiguration config;
        public BookContext(IConfiguration _config)
        {

            config = _config;

        }
        public DbSet<Bookstore> bookstores { set; get; }
        public DbSet<Auther> authers { set; get; }
        public DbSet<Category> categories { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer("data source =DESKTOP-IG9P67E\\sql2008; initial catalog = BookStore; integrated security = true");
            optionsBuilder.UseSqlServer(config.GetConnectionString("xyz"));
            base.OnConfiguring(optionsBuilder);
        }

    }
    
}
