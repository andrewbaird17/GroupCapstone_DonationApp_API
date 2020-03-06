using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone_Donation_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Capstone_Donation_API.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donor>().HasData(
                new Donor { }



                );
        }

        public DbSet<Donor> Donors { get; set; }
    }
}
