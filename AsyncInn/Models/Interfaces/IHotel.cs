using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotel
    {
        // Create 
        /// <summary>
        /// To add a Hotel object to the database using HotelDTO
        /// </summary>
        /// <param name="repo">passing the created Hotel</param>
        /// <returns>return the created object in HotelDTO type</returns>
        Task<HotelDTO> Create(HotelDTO repo);

        // GET All
        /// <summary>
        /// to get all the Hotels data from the database
        /// </summary>
        /// <returns>it returns all the Hotel data from the database in HotelDTO type</returns>
        Task<List<HotelDTO>> GetAll();

        // GET By Id
        /// <summary>
        /// to get a specific Hotel object
        /// </summary>
        /// <param name="repoId">passing the id of the hotel that we want</param>
        /// <returns>it return a specific Hotel object in HotelDTO type</returns>
        Task<HotelDTO> GetbyId(int repoId);

        // Update
        /// <summary>
        /// to update a specific Hotel object
        /// </summary>
        /// <param name="id">passing the id of the hotel that we want</param>
        /// <param name="repo">passing the Editied Hotel object</param>
        /// <returns>it return the updated hotel object in HotelDTO type</returns>
        Task<HotelDTO> Update(int id, HotelDTO repo);

        // Delete 
        /// <summary>
        /// to delete a specific Hotel object
        /// </summary>
        /// <param name="id">passing the id of the hotel that we want</param>
        /// <returns>nothing</returns>
        Task Delete(int id);
    }
}
