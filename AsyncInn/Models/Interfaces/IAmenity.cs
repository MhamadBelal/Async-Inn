namespace AsyncInn.Models.Interfaces
{
    public interface IAmenity
    {
        // Create 
        Task<Amenity> Create(Amenity repo);

        // GET All
        Task<List<Amenity>> GetAll();

        // GET By Id

        Task<Amenity> GetbyId(int repoId);

        // Update
        Task<Amenity> Update(int id, Amenity repo);

        // Delete 

        Task Delete(int id);
    }
}
