using AsyncInn.Data;
using AsyncInn.Models.DTOs;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class HotelsSevice : IHotel
    {
        private AsyncInnDbContext _context;

        public HotelsSevice(AsyncInnDbContext context)
        { 
            _context = context;
        }
        /// <summary>
        /// To add a Hotel object to the database using HotelDTO
        /// </summary>
        /// <param name="hotel">passing the created Hotel</param>
        /// <returns>return the created object in HotelDTO type</returns>
        public async Task<HotelDTO> Create(HotelDTO hotel)
        {
            var Hotel = new Hotel
            {
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone
            };

            _context.Hotels.Add(Hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }
        /// <summary>
        /// to delete a specific Hotel object
        /// </summary>
        /// <param name="id">passing the id of the hotel that we want</param>
        /// <returns>nothing</returns>
        public async Task Delete(int id)
        {
            var hotel =await _context.Hotels.FindAsync(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// to get a specific Hotel object
        /// </summary>
        /// <param name="hotelId">passing the id of the hotel that we want</param>
        /// <returns>it return a specific Hotel object in HotelDTO type</returns>
        public async Task<HotelDTO> GetbyId(int hotelId)
        {
            //Hotel hotel = await _context.Hotels.FindAsync(hotelId);
            //return hotel;

            var hotel = await _context.Hotels
        .Include(h => h.HotelRooms)
            .ThenInclude(hr => hr.Room)
                .ThenInclude(r => r.Amenities)
                    .ThenInclude(ra => ra.Amenity)
        .FirstOrDefaultAsync(h => h.ID == hotelId);

            if (hotel == null)
                return null;

            var HotelDTO = new HotelDTO
            {
                ID = hotel.ID,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone,
                Rooms = hotel.HotelRooms.Select(hr => new HotelRoomDTO
                {
                    HotelID = hr.HotelID,
                    RoomNumber = hr.RoomNumber,
                    Rate = hr.Rate,
                    PetFriendly = hr.PetFriendly,
                    RoomID = hr.RoomID,
                    Room = new RoomDTO
                    {
                        ID = hr.Room.ID,
                        Name = hr.Room.Name,
                        Layout = hr.Room.Layout.ToString(),
                        Amenities = hr.Room.Amenities.Select(a => new AmenityDTO
                        {
                            ID = a.Amenity.ID,
                            Name = a.Amenity.Name
                        }).ToList()
                    }
                }).ToList()
            };

            return HotelDTO;
        }
        /// <summary>
        /// to get all the Hotels data from the database
        /// </summary>
        /// <returns>it returns all the Hotel data from the database in HotelDTO type</returns>
        public async Task<List<HotelDTO>> GetAll()
        {
        var hotels = await _context.Hotels
        .Include(h => h.HotelRooms)
            .ThenInclude(hr => hr.Room)
                .ThenInclude(r => r.Amenities)
                    .ThenInclude(ra => ra.Amenity)
                        .ToListAsync();

            var HotelDTO = hotels.Select(hotel=>new HotelDTO
            {
                ID = hotel.ID,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone,
                Rooms = hotel.HotelRooms.Select(hr => new HotelRoomDTO
                {
                    HotelID = hr.HotelID,
                    RoomNumber = hr.RoomNumber,
                    Rate = hr.Rate,
                    PetFriendly = hr.PetFriendly,
                    RoomID = hr.RoomID,
                    Room = new RoomDTO
                    {
                        ID = hr.Room.ID,
                        Name = hr.Room.Name,
                        Layout = hr.Room.Layout.ToString(),
                        Amenities = hr.Room.Amenities.Select(a => new AmenityDTO
                        {
                            ID = a.Amenity.ID,
                            Name = a.Amenity.Name
                        }).ToList()
                    }
                }).ToList()
            }).ToList();
            return HotelDTO;
        }
        /// <summary>
        /// to update a specific Hotel object
        /// </summary>
        /// <param name="id">passing the id of the hotel that we want</param>
        /// <param name="hotel">passing the Editied Hotel object</param>
        /// <returns>it return the updated hotel object in HotelDTO type</returns>
        public async Task<HotelDTO> Update(int id, HotelDTO hotel)
        {
            var Hotel = await _context.Hotels.FindAsync(id);
            if(Hotel!=null)
            {
                _context.Entry(Hotel).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return hotel;
        }
    }
}
