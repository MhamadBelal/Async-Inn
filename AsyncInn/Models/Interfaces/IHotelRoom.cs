using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        // Create 
        /// <summary>
        /// To add a HotelRoom object to the database using HotelRoomDTO
        /// </summary>
        /// <param name="hotelId">passing the hotel id that I want to make HotelRoom object from</param>
        /// <param name="hotelRoom">passing the crreated HotelRoom object using HotelRoomDTO type</param>
        /// <returns>the created HotelRoom object in HotelRoomDTO type</returns>
        Task<HotelRoomDTO> Create(int hotelId, HotelRoomDTO hotelRoom);

        // GET All
        /// <summary>
        /// to get all the RoomHotel realted to a specific hotel objects from the database
        /// </summary>
        /// <param name="hotelId">the hotel that I want to return all the realted HotelRoom objects</param>
        /// <returns>all the RoomHotel realted to a specific hotel objects from the database in HotelRoomDTO type</returns>
        Task<List<HotelRoomDTO>> GetAll(int hotelId);

        // GET By Id
        /// <summary>
        /// to get a specific HotelRoom object based on roomId and hotelId
        /// </summary>
        /// <param name="roomId">the roomId of the HotelRoom</param>
        /// <param name="hotelId">the hotelId of the HotelRoom</param>
        /// <returns>a specific HotelRoom object based on roomId and hotelId in HotelRoomDTO type</returns>
        Task<HotelRoomDTO> GetbyId(int roomId, int hotelId);

        // Update
        /// <summary>
        /// to modify a specific HotelRoom object based on roomId and hotelId
        /// </summary>
        /// <param name="hotelId">the hotelId of the HotelRoom that I want to edit</param>
        /// <param name="roomId">the roomId of the HotelRoom that I want to edit</param>
        /// <param name="hotelRoom">the modified object in HotelRoomDTO type</param>
        /// <returns>the modified object in HotelRoomDTO type</returns>
        Task<HotelRoomDTO> Update(int hotelId, int roomId, HotelRoomDTO hotelRoom);

        // Delete 
        /// <summary>
        /// to delete a HotelRoom object from the database
        /// </summary>
        /// <param name="roomId">the roomId of the HotelRoom that I want to edit</param>
        /// <param name="hotelId">the hotelId of the HotelRoom that I want to edit</param>
        /// <returns>nothing</returns>
        Task Delete(int roomId, int hotelId);
    }
}
