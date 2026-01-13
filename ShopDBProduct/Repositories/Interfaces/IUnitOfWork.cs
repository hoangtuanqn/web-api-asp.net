namespace ShopDBProduct.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        // các repo
        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }
        public IOrderRepository Orders { get; }


        // cố định
        public Task BeginTransaction();
        public Task RollBackAsync();
        public Task<int> SaveChangeAsync();
        public Task CommitAsync();

    }
}
