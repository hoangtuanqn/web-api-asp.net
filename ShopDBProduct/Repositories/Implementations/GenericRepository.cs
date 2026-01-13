using Microsoft.EntityFrameworkCore;
using ShopDBProduct.Data;
using ShopDBProduct.Repositories.Interfaces;
using System;

namespace ShopDBProduct.Repositories.Implementations
{
    // document: https://dev.to/karenpayneoregon/gentle-introduction-to-generic-repository-pattern-with-c-1jn0
    // https://medium.com/@dnzcnyksl/generic-repository-pattern-in-c-354ec183dc84
    // Xem ví dụ ở gần cuối trang mới có code mẫu
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            var ent = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return ent.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
