using ecommerce_web_api.Data;
using ecommerce_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_web_api.Repositories
{
    public class OrderRepository : ICrudRepository<Order>
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Order> AddAsync(Order entity)
        {
            _context.Orders.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Orders.FindAsync(id);

            if (product != null)
            {
                _context.Orders.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Products)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Products)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task UpdateAsync(Order entity)
        {
            _context.Orders .Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
