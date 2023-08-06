using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        // Create 
        Task<HotelRoomDTO> Create(int hotelId, HotelRoomDTO hotelRoom);

        // GET All
        Task<List<HotelRoomDTO>> GetAll(int hotelId);

        // GET By Id

        Task<HotelRoomDTO> GetbyId(int roomId, int hotelId);

        // Update
        Task<HotelRoomDTO> Update(int hotelId, int roomId, HotelRoomDTO hotelRoom);

        // Delete 

        Task Delete(int roomId, int hotelId);
    }
}
