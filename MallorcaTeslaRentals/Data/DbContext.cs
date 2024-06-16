using MallorcaTeslaRentals.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MallorcaTeslaRentals.Data
{
    

public class ApplicationDbContext : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Car { get; set; }

        public DbSet<Location> Locations { get; set; }  

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }

}

