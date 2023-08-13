using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using AsyncInn.Models.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Sqlite.Scaffolding.Internal;
using NuGet.Protocol;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AsyncInn.Models.Room;

namespace AsyncInnTests
{
    public class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly AsyncInnDbContext _db;
        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new AsyncInnDbContext(
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseSqlite(_connection).Options);

            _db.Database.EnsureCreated();
        }

        #region RoomService
        public async Task<Room> CreateAndSaveTestRoom()
        {
            var room = new Room()
            {
                Name = "Test1",
                Layout = Room.RoomLayout.OneBedroom
            };
            _db.Rooms.Add(room);

            await _db.SaveChangesAsync();

            return room;
        }


        public async Task<List<Room>> getAllRoomsTest()
        {
            var room1 = new Room
            {
               Name="hello one",Layout=Room.RoomLayout.OneBedroom
            };

            var room2 = new Room
            {
                Name = "hello two",
                Layout = Room.RoomLayout.TwoBedroom
            };

            var room3 = new Room
            {
                Name = "hello studio",
                Layout = Room.RoomLayout.Studio
            };


            _db.Rooms.Add(room1);
            _db.Rooms.Add(room2);
            _db.Rooms.Add(room3);

            await _db.SaveChangesAsync();

            var rooms= await _db.Rooms.ToListAsync();

            return rooms;

        }

        public async Task<Room> UpdateAndSaveRoomTest(int roomId)
        {
            var Room = await _db.Rooms.FindAsync(roomId);
            if (Room != null)
            {
                Room.Name = "updateTest";
                Room.Layout = Room.RoomLayout.TwoBedroom;
            }
            _db.Rooms.Update(Room);
            await _db.SaveChangesAsync();
            return Room;
        }


        public async Task<RoomAmenities> AddAmenityToRoomTest(int roomId,int AmenityId)
        {
            var roomAmenities = new RoomAmenities
            {
                RoomID = roomId,
                AmenityID = AmenityId
            };

            _db.RoomAmenities.Add(roomAmenities);

            await _db.SaveChangesAsync();

            return roomAmenities;
        }


        public async Task RemoveAmentityFromRoomTest(int roomId, int AmenityId)
        {
            var roomAmenity = await _db.RoomAmenities.FirstOrDefaultAsync(x => x.RoomID == roomId && x.AmenityID == AmenityId);

            _db.RoomAmenities.Remove(roomAmenity!);
            await _db.SaveChangesAsync();
        }
        #endregion


        #region HotelService
        public async Task<Hotel> CreateAndSaveTestHotel()
        {
            var hotel = new Hotel()
            {
                Name = "Test1",
                StreetAddress="TestStreet",
                City="TestCity",
                State="TestState",
                Country="TestCountry",
                Phone="0793242121"
            };
            _db.Hotels.Add(hotel);

            await _db.SaveChangesAsync();

            return hotel;
        }



        public async Task<List<Hotel>> getAllHotelsTest()
        {
            var hotel1 = new Hotel
            {
                Name = "Test1",
                StreetAddress = "TestStreet1",
                City = "TestCity1",
                State = "TestState1",
                Country = "TestCountry1",
                Phone = "0793242121"
            };

            var hotel2 = new Hotel
            {
                Name = "Test2",
                StreetAddress = "TestStreet2",
                City = "TestCity2",
                State = "TestState2",
                Country = "TestCountry2",
                Phone = "0793242121"
            };

            var hotel3 = new Hotel
            {
                Name = "Test3",
                StreetAddress = "TestStreet3",
                City = "TestCity3",
                State = "TestState3",
                Country = "TestCountry3",
                Phone = "0793242121"
            };


            _db.Hotels.Add(hotel1);
            _db.Hotels.Add(hotel2);
            _db.Hotels.Add(hotel3);

            await _db.SaveChangesAsync();

            var Hotels = await _db.Hotels.ToListAsync();

            return Hotels;

        }

        public async Task<Hotel> UpdateAndSaveHotelTest(int hotelId)
        {
            var Hotel = await _db.Hotels.FindAsync(hotelId);
            if (Hotel != null)
            {
                Hotel.Name = "updateTest";
                Hotel.StreetAddress = "updateTestStreet";
                Hotel.City = "updateTestCity";
                Hotel.State = "updateTestState";
                Hotel.Country = "updateTestCountry";
                Hotel.Phone = "0793242121";
            }
            _db.Hotels.Update(Hotel);
            await _db.SaveChangesAsync();
            return Hotel;
        }

        #endregion





        #region Amenity

        public async Task<Amenity> CreateAndSaveTestAmenity()
        {
            var amenity = new Amenity()
            {
                Name = "Test1"
            };
            _db.Amenities.Add(amenity);

            await _db.SaveChangesAsync();

            return amenity;
        }

        public async Task<List<Amenity>> getAllAmenitiesTest()
        {
            var amenity1 = new Amenity
            {
                Name = "Test1"
            };

            var amenity2 = new Amenity
            {
                Name = "Test2"
            };

            var amenity3 = new Amenity
            {
                Name = "Test3",
            };


            _db.Amenities.Add(amenity1);
            _db.Amenities.Add(amenity2);
            _db.Amenities.Add(amenity3);

            await _db.SaveChangesAsync();

            var Amenities = await _db.Amenities.ToListAsync();

            return Amenities;

        }

        public async Task<Amenity> UpdateAndSaveAmenityTest(int amenityId)
        {
            var Amenity = await _db.Amenities.FindAsync(amenityId);
            if (Amenity != null)
            {
                Amenity.Name = "updateTest";
            }
            _db.Amenities.Update(Amenity);
            await _db.SaveChangesAsync();
            return Amenity;
        }


        public void Dispose()
        {
        _db?.Dispose();

        _connection?.Dispose();
        }
        #endregion
    }
}
