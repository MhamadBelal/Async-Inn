using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        // Create 
        Task<RoomDTO> Create(RoomDTO repo);

        // GET All
        Task<List<RoomDTO>> GetAll();

        // GET By Id

        Task<RoomDTO> GetbyId(int repoId);

        // Update
        Task<RoomDTO> Update(int id, RoomDTO repo);

        // Delete 

        Task Delete(int id);


        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
