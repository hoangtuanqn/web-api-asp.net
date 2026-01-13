namespace ShopDBProduct.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }
        public IOrderRepository Orders { get; }

        public Task<int> SaveChangeAsync();
    }
}
