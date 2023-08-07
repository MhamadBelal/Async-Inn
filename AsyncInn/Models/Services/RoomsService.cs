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
        /// <summary>
        /// To add a Room object to the database using RoomDTO
        /// </summary>
        /// <param name="room">passing the created Room</param>
        /// <returns>return the created object in RoomDTO type</returns>
        public async Task<RoomDTO> Create(RoomDTO room)
        {
            var Room = new Room
            {
                Name = room.Name,
                Layout = Enum.Parse<RoomLayout>(room.Layout),
            };
            _context.Rooms.Add(Room);
            await _context.SaveChangesAsync();
            return room;
        }
        /// <summary>
        /// to delete a specific room object
        /// </summary>
        /// <param name="id">passing the id of the room that we want</param>
        /// <returns>nothing</returns>
        public async Task Delete(int id)
        {
            var room =await _context.Rooms.FindAsync(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// to get a specific Room object
        /// </summary>
        /// <param name="roomId">passing the id of the room that we want</param>
        /// <returns>it return a specific Room object in RoomDTO type</returns>
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
        /// <summary>
        /// to get all the Rooms data from the database
        /// </summary>
        /// <returns>it returns all the Room data from the database in RoomDTO type</returns>
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
        /// <summary>
        /// to update a specific Room object
        /// </summary>
        /// <param name="id">passing the id of the room that we want</param>
        /// <param name="room">passing the Editied Room object</param>
        /// <returns>it return the updated room object in RoomDTO type</returns>
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
        /// <summary>
        /// to add an amenityRoom object. In other words, to to add amenity to a room
        /// </summary>
        /// <param name="roomId">passing the room id that I want to add amenity to</param>
        /// <param name="amenityId">passing the amenity id that I want to add</param>
        /// <returns>nothing</returns>
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
        /// <summary>
        /// to remove an amenityRoom object. In other words, to to remove amenity from a room
        /// </summary>
        /// <param name="roomId">passing the room id that I want to remove amenity from</param>
        /// <param name="amenityId">passing the amenity id that I want to remove</param>
        /// <returns>nothing</returns>
        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var roomAmenity = await _context.RoomAmenities.FirstOrDefaultAsync(x=>x.RoomID == roomId && x.AmenityID == amenityId);

            _context.Entry(roomAmenity).State = EntityState.Deleted;

            await _context.SaveChangesAsync();

        }
    }
}
