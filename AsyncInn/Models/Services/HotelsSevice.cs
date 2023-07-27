using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
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

        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)
        {
            Hotel hotel = await GetbyId(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

        public async Task<Hotel> GetbyId(int hotelId)
        {
            Hotel hotel = await _context.Hotels.FindAsync(hotelId);
            return hotel;
        }

        public async Task<List<Hotel>> GetAll()
        {
            var hotles = await _context.Hotels.ToListAsync();

            return hotles;
        }

        public async Task<Hotel> Update(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
