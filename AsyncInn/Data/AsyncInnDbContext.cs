using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { ID = 1, Name="Blue Hotel", StreetAddress="University Street", City="Amman", State="Middle East", Country="Jordan", Phone="0791420372" },
                new Hotel { ID = 2, Name = "Red Hotel", StreetAddress = "University Street", City = "Amman", State = "Middle East", Country = "Jordan", Phone = "0791420372" },
                new Hotel { ID = 3, Name = "Green Hotel", StreetAddress = "University Street", City = "Amman", State = "Middle East", Country = "Jordan", Phone = "0791420372" }
                );
            modelBuilder.Entity<Room>().HasData(
                new Room { ID=1, Name="Blue Room", Layout=222},
                new Room { ID = 2, Name = "Red Room", Layout = 222 },
                new Room { ID = 3, Name = "Green Room", Layout = 222 }
                );
            modelBuilder.Entity<Amenity>().HasData(
                new Room { ID = 1, Name = "Blue Amenity" },
                new Room { ID = 2, Name = "Red Amenity" },
                new Room { ID = 3, Name = "Green Amenity" }
                );
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }

    }
}
