using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRUs_API.ShopRu.DataAccess.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
           : base(options)
        {
        }

        //DbSets that connects to the database
        //public DbSet<Patron> Patrons { get; set; }

    }
}
