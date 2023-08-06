using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenity
    {
        // Create 
        Task<AmenityDTO> Create(AmenityDTO repo);

        // GET All
        Task<List<AmenityDTO>> GetAll();

        // GET By Id

        Task<AmenityDTO> GetbyId(int repoId);

        // Update
        Task<AmenityDTO> Update(int id, AmenityDTO repo);

        // Delete 

        Task Delete(int id);
    }
}
