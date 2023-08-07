using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        // Create 
        /// <summary>
        /// To add a Room object to the database using RoomDTO
        /// </summary>
        /// <param name="repo">passing the created Room</param>
        /// <returns>return the created object in RoomDTO type</returns>
        Task<RoomDTO> Create(RoomDTO repo);

        // GET All
        /// <summary>
        /// to get all the Rooms data from the database
        /// </summary>
        /// <returns>it returns all the Room data from the database in RoomDTO type</returns>
        Task<List<RoomDTO>> GetAll();

        // GET By Id
        /// <summary>
        /// to get a specific Room object
        /// </summary>
        /// <param name="repoId">passing the id of the room that we want</param>
        /// <returns>it return a specific Room object in RoomDTO type</returns>
        Task<RoomDTO> GetbyId(int repoId);

        // Update
        /// <summary>
        /// to update a specific Room object
        /// </summary>
        /// <param name="id">passing the id of the room that we want</param>
        /// <param name="repo">passing the Editied Room object</param>
        /// <returns>it return the updated room object in RoomDTO type</returns>
        Task<RoomDTO> Update(int id, RoomDTO repo);

        // Delete 
        /// <summary>
        /// to delete a specific room object
        /// </summary>
        /// <param name="id">passing the id of the room that we want</param>
        /// <returns>nothing</returns>
        Task Delete(int id);

        /// <summary>
        /// to add an amenityRoom object. In other words, to to add amenity to a room
        /// </summary>
        /// <param name="roomId">passing the room id that I want to add amenity to</param>
        /// <param name="amenityId">passing the amenity id that I want to add</param>
        /// <returns>nothing</returns>
        Task AddAmenityToRoom(int roomId, int amenityId);

        /// <summary>
        /// to remove an amenityRoom object. In other words, to to remove amenity from a room
        /// </summary>
        /// <param name="roomId">passing the room id that I want to remove amenity from</param>
        /// <param name="amenityId">passing the amenity id that I want to remove</param>
        /// <returns>nothing</returns>
        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
