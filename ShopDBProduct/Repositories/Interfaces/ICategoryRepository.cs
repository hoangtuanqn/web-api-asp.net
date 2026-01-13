using ShopDBProduct.Entities;

namespace ShopDBProduct.Repositories.Interfaces
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        Task<Category?> GetByIdWithDetailProductAsync(int id);
    }
}
