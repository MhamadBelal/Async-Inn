using AsyncInn.Data;
using AsyncInn.Models.DTOs;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class AmenitiesService : IAmenity
    {
        private AsyncInnDbContext _context;

        public AmenitiesService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<AmenityDTO> Create(AmenityDTO amenity)
        {
            var Amneity = new Amenity
            {
                Name=amenity.Name
            };
            _context.Amenities.Add(Amneity);
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task Delete(int id)
        {
            var amenity = await _context.Amenities.FindAsync(id);
            if (amenity != null)
            {
                _context.Entry(amenity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<AmenityDTO> GetbyId(int amenityId)
        {
            var amenity = await _context.Amenities.FindAsync(amenityId);
            if (amenity == null)
            {
                return null;
            }
            var Amenity = new AmenityDTO
            {
                ID = amenity.ID,
                Name = amenity.Name
            };
            return Amenity;
        }

        public async Task<List<AmenityDTO>> GetAll()
        {
            var amenity = await _context.Amenities.ToListAsync();
            var Amenity = amenity.Select(a=>new AmenityDTO
            {
                ID = a.ID,
                Name = a.Name
            }).ToList();
            return Amenity;
        }

        public async Task<AmenityDTO> Update(int id, AmenityDTO amenity)
        {
            var Amenity = await _context.Amenities.FindAsync(id);

            if(Amenity != null)
            {
                Amenity.Name = amenity.Name;
                await _context.SaveChangesAsync();
            }
            return amenity;
        }
    }
}
