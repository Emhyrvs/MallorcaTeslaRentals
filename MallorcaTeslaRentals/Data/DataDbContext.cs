using MallorcaTeslaRentals.Models;
using Microsoft.EntityFrameworkCore;

namespace MallorcaTeslaRentals.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; } 

        public DbSet<Location> Locations { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
    .HasOne(r => r.ReturnLocation)
    .WithMany()
    .HasForeignKey(r => r.ReturnLocationId)
    .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.PickupLocation)
                .WithMany()
                .HasForeignKey(r => r.PickupLocationId)
                .OnDelete(DeleteBehavior.NoAction);  

        }
    }
}
