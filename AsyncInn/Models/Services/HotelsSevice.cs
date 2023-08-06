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
        
        public async Task Delete(int id)
        {
            var hotel =await _context.Hotels.FindAsync(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        
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
        
        public async Task<Hotel> Update(int id, Hotel hotel)
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
