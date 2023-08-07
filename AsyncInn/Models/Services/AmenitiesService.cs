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
        /// <summary>
        /// To add a Amenity object to the database using AmenityDTO
        /// </summary>
        /// <param name="amenity">passing the created Amenity</param>
        /// <returns>return the created object in AmenityDTO type</returns>
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
        /// <summary>
        /// to delete a specific Amenity object
        /// </summary>
        /// <param name="id">passing the id of the amenity that we want</param>
        /// <returns>nothing</returns>
        public async Task Delete(int id)
        {
            var amenity = await _context.Amenities.FindAsync(id);
            if (amenity != null)
            {
                _context.Entry(amenity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// to get a specific Amenity object
        /// </summary>
        /// <param name="amenityId">passing the id of the amenity that we want</param>
        /// <returns>it return a specific Amenity object in AmenityDTO type</returns>
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
        /// <summary>
        /// to get all the Amenity data from the database
        /// </summary>
        /// <returns>it returns all the Amenity data from the database in AmenityDTO type</returns>
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
        /// <summary>
        /// to update a specific Amenity object
        /// </summary>
        /// <param name="id">passing the id of the amenity that we want</param>
        /// <param name="amenity">passing the Editied Amenity object</param>
        /// <returns>it return the updated amenity object in AmenityDTO type</returns>
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
