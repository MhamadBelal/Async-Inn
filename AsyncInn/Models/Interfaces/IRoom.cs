namespace AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        // Create 
        Task<Room> Create(Room repo);

        // GET All
        Task<List<Room>> GetAll();

        // GET By Id

        Task<Room> GetbyId(int repoId);

        // Update
        Task<Room> Update(int id, Room repo);

        // Delete 

        Task Delete(int id);


        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
