namespace AsyncInn.Models.Interfaces
{
    public interface IHotel
    {
        // Create 
        Task<Hotel> Create(Hotel repo);

        // GET All
        Task<List<Hotel>> GetAll();

        // GET By Id

        Task<Hotel> GetbyId(int repoId);

        // Update
        Task<Hotel> Update(int id, Hotel repo);

        // Delete 

        Task Delete(int id);
    }
}
