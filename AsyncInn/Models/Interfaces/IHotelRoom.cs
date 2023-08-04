namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        // Create 
        Task<HotelRoom> Create(int hotelId, HotelRoom hotelRoom);

        // GET All
        Task<List<HotelRoom>> GetAll(int hotelId);

        // GET By Id

        Task<HotelRoom> GetbyId(int roomId, int hotelId);

        // Update
        Task<HotelRoom> Update(HotelRoom hotelRoom);

        // Delete 

        Task Delete(int roomId, int hotelId);
    }
}
