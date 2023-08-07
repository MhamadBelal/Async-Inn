using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenity
    {
        // Create 
        /// <summary>
        /// To add a Amenity object to the database using AmenityDTO
        /// </summary>
        /// <param name="repo">passing the created Amenity</param>
        /// <returns>return the created object in AmenityDTO type</returns>
        Task<AmenityDTO> Create(AmenityDTO repo);

        // GET All
        /// <summary>
        /// to get all the Amenity data from the database
        /// </summary>
        /// <returns>it returns all the Amenity data from the database in AmenityDTO type</returns>
        Task<List<AmenityDTO>> GetAll();

        // GET By Id
        /// <summary>
        /// to get a specific Amenity object
        /// </summary>
        /// <param name="repoId">passing the id of the amenity that we want</param>
        /// <returns>it return a specific Amenity object in AmenityDTO type</returns>
        Task<AmenityDTO> GetbyId(int repoId);

        // Update
        /// <summary>
        /// to update a specific Amenity object
        /// </summary>
        /// <param name="id">passing the id of the amenity that we want</param>
        /// <param name="repo">passing the Editied Amenity object</param>
        /// <returns>it return the updated amenity object in AmenityDTO type</returns>
        Task<AmenityDTO> Update(int id, AmenityDTO repo);

        // Delete 
        /// <summary>
        /// to delete a specific Amenity object
        /// </summary>
        /// <param name="id">passing the id of the amenity that we want</param>
        /// <returns>nothing</returns>
        Task Delete(int id);
    }
}
