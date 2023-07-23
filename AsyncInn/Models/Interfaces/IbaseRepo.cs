namespace AsyncInn.Models.Interfaces
{
    public interface IbaseRepo<T>
    {
        // Create 
        Task<T> Create(T repo);

        // GET All
        Task<List<T>> GetAll();

        // GET Course By Id

        Task<T> GetbyId(int repoId);

        // Update
        Task<T> Update(int id, T repo);

        // Delete 

        Task Delete(int id);
    }
}
