using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotel
    {
        // Create 
        Task<HotelDTO> Create(HotelDTO repo);

        // GET All
        Task<List<HotelDTO>> GetAll();

        // GET By Id

        Task<HotelDTO> GetbyId(int repoId);

        // Update
        Task<HotelDTO> Update(int id, HotelDTO repo);

        // Delete 

        Task Delete(int id);
    }
}
