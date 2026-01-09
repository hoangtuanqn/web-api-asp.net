using ShopDBProduct.Entities;

namespace ShopDBProduct.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsysnc(Order order);
        Task SaveChangesAsync();
    }
}
