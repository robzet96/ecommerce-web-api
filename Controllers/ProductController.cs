using ecommerce_web_api.Models;
using ecommerce_web_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ecommerce_web_api.DTO;

namespace ecommerce_web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ICrudService<Product> _productService;

        public ProductController(ICrudService<Product> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDTO>>> GetAll()
        {
            var products = await _productService.GetAllAsync();

            var result = products.Select(p => new ProductReadDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Discount = p.Discount,
                OrderIds = p.Orders.Select(o => o.Id).ToList()
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDTO>> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            var result = new ProductReadDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Discount = product.Discount,
                OrderIds = product.Orders.Select(o => o.Id).ToList()
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            var createdProduct = await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest();

            await _productService.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}
