namespace ShopDBProduct.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChangeAsync();
    }
}
