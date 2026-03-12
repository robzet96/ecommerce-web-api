using ecommerce_web_api.Models;
using ecommerce_web_api.Repositories;

namespace ecommerce_web_api.Services
{
    public class ProductService : ICrudService<Product>
    {
        private readonly ICrudRepository<Product> _productRepository;

        public ProductService(ICrudRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Product> AddAsync(Product entity)
        {
            return await _productRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(Product entity)
        {
            await _productRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
