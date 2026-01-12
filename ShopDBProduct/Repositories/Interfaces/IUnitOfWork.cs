namespace ShopDBProduct.Repositories.Interfaces
{
    // IDisposable inherit nó sẽ tự động dọn dẹp sau khi sử dụng xong
    public interface IUnitOfWork: IDisposable
    {
        public Task<int> SaveChangeAsync();
    }
}
