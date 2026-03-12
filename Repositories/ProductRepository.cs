using ecommerce_web_api.Data;
using ecommerce_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_web_api.Repositories
{
    public class ProductRepository : ICrudRepository<Product>
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddAsync(Product entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Orders)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Orders)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Product entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
