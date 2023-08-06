using AsyncInn.Data;
using AsyncInn.Models.DTOs;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static AsyncInn.Models.Room;

namespace AsyncInn.Models.Services
{
    public class RoomsService : IRoom
    {
        private AsyncInnDbContext _context;

        public RoomsService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<RoomDTO> Create(RoomDTO room)
        {
            var Room = new Room
            {
                Name = room.Name,
                Layout= Enum.Parse<RoomLayout>(room.Layout)
            };
            _context.Rooms.Add(Room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int id)
        {
            var room =await _context.Rooms.FindAsync(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<RoomDTO> GetbyId(int roomId)
        {
            var room = await _context.Rooms.Include(ar => ar.Amenities)
                .ThenInclude(a => a.Amenity).FirstOrDefaultAsync();
            if (room == null)
                return null;

            var Room = new RoomDTO
            {
                ID = room.ID,
                Name = room.Name,
                Layout = room.Layout.ToString(),
                Amenities = room.Amenities.Select(a => new AmenityDTO
                {
                    ID=a.Amenity.ID,
                    Name=a.Amenity.Name
                }).ToList()
            };

            return Room;
        }

        public async Task<List<RoomDTO>> GetAll()
        {
            var room = await _context.Rooms.Include(ar => ar.Amenities)
                .ThenInclude(a => a.Amenity).ToListAsync();
            if (room == null)
                return null;

            var Room = room.Select(a=>new RoomDTO
            {
                ID = a.ID,
                Name = a.Name,
                Layout = a.Layout.ToString(),
                Amenities = a.Amenities.Select(a => new AmenityDTO
                {
                    ID = a.Amenity.ID,
                    Name = a.Amenity.Name
                }).ToList()
            }).ToList();

            return Room;
        }

        public async Task<RoomDTO> Update(int id, RoomDTO room)
        {
            var Room =await _context.Rooms.FindAsync(id);
            if(Room!=null)
            {
                Room.Name = room.Name;
                Room.Layout = Enum.Parse<RoomLayout>(room.Layout);
            }
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenities = new RoomAmenities
            {
                RoomID = roomId,
                AmenityID = amenityId
            };

            _context.Entry(roomAmenities).State = EntityState.Added;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var roomAmenity = await _context.RoomAmenities.FirstOrDefaultAsync(x=>x.RoomID == roomId && x.AmenityID == amenityId);

            _context.Entry(roomAmenity).State = EntityState.Deleted;

            await _context.SaveChangesAsync();

        }
    }
}
