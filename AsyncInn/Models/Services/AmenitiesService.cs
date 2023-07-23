using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class AmenitiesService : IbaseRepo<Amenity>
    {
        private AsyncInnDbContext _context;

        public AmenitiesService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<Amenity> Create(Amenity amenity)
        {
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await GetbyId(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Amenity> GetbyId(int amenityId)
        {
            Amenity amenity = await _context.Amenities.FindAsync(amenityId);
            return amenity;
        }

        public async Task<List<Amenity>> GetAll()
        {
            var amenities = await _context.Amenities.ToListAsync();

            return amenities;
        }

        public async Task<Amenity> Update(int id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
