using ecommerce_web_api.Models;
using ecommerce_web_api.Repositories;

namespace ecommerce_web_api.Services
{
    public class OrderService : ICrudService<Order>
    {
        private readonly ICrudRepository<Order> _orderRepository;

        public OrderService(ICrudRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<Order> AddAsync(Order entity)
        {
            return await _orderRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(Order entity)
        {
            await _orderRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}
