using Microsoft.EntityFrameworkCore;
using ShopDBProduct.Data;
using ShopDBProduct.Entities;
using ShopDBProduct.Repositories.Interfaces;

namespace ShopDBProduct.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context): base(context)
        {
            _context = context;
        }
    }
}
