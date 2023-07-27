using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class HotelRoomRepository : IHotelRoom
    {
        private AsyncInnDbContext _context;

        public HotelRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }


        public async Task<HotelRoom> Create(HotelRoom hotelRoom)
        {
            _context.HotelRooms.Add(hotelRoom);
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task Delete(int roomId, int hotelId)
        {
            HotelRoom hotel = await GetbyId(roomId, hotelId);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<HotelRoom>> GetAll(int hotelId)
        {
            var hotelRooms = await _context.HotelRooms.ToListAsync();

            return hotelRooms;
        }

        public async Task<HotelRoom> GetbyId(int roomId, int hotelId)
        {
            HotelRoom hotelRoom = await _context.HotelRooms.FirstOrDefaultAsync(x=>x.RoomID==roomId && x.HotelID==hotelId);
            return hotelRoom;
        }

        public async Task<HotelRoom> Update(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }
    }
}
