using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class RoomsService : IbaseRepo<Room>
    {
        private AsyncInnDbContext _context;

        public RoomsService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<Room> Create(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int id)
        {
            Room room = await GetbyId(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetbyId(int roomId)
        {
            Room room = await _context.Rooms.FindAsync(roomId);
            return room;
        }

        public async Task<List<Room>> GetAll()
        {
            var rooms = await _context.Rooms.ToListAsync();

            return rooms;
        }

        public async Task<Room> Update(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
    }
}
