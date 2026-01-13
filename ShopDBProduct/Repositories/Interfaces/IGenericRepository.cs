namespace ShopDBProduct.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // Query
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);


        // Command
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

    }
}
