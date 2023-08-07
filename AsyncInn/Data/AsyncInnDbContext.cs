using AsyncInn.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Numerics;
using static AsyncInn.Models.Room;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : IdentityDbContext<ApplicationUser>
    {
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { ID = 1, Name="Blue Hotel", StreetAddress="University Street", City="Amman", State="Middle East", Country="Jordan", Phone="0791420372" },
                new Hotel { ID = 2, Name = "Red Hotel", StreetAddress = "University Street", City = "Amman", State = "Middle East", Country = "Jordan", Phone = "0791420372" },
                new Hotel { ID = 3, Name = "Green Hotel", StreetAddress = "University Street", City = "Amman", State = "Middle East", Country = "Jordan", Phone = "0791420372" }
                );
            modelBuilder.Entity<Room>().HasData(
                new Room { ID=1, Name="Blue Room", Layout= RoomLayout.Studio},
                new Room { ID = 2, Name = "Red Room", Layout = RoomLayout.TwoBedroom },
                new Room { ID = 3, Name = "Green Room", Layout = RoomLayout.OneBedroom }
                );
            modelBuilder.Entity<Amenity>().HasData(
                new Room { ID = 1, Name = "Blue Amenity" },
                new Room { ID = 2, Name = "Red Amenity" },
                new Room { ID = 3, Name = "Green Amenity" }
                );

            modelBuilder.Entity<RoomAmenities>().HasKey(
                roomAmenities => new {
                    roomAmenities.AmenityID,
                    roomAmenities.RoomID
                }
                );

            modelBuilder.Entity<HotelRoom>().HasKey(
                hotelRoom => new {
                hotelRoom.HotelID,
                hotelRoom.RoomID
                });
        }



        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }

    }
}
