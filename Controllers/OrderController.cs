using ecommerce_web_api.Data;
using ecommerce_web_api.DTO;
using ecommerce_web_api.Models;
using ecommerce_web_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICrudService<Order> _orderService;
        private readonly AppDbContext _context;

        public OrderController(ICrudService<Order> orderService, AppDbContext context)
        {
            _orderService = orderService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Create(CreateOrderDTO dto)
        {
            var products = await _context.Products
                .Where(p => dto.ProductIds.Contains(p.Id))
                .ToListAsync();

            if (products.Count != dto.ProductIds.Count)
                return BadRequest("One or more products do not exist.");

            var order = new Order
            {
                Products = products,
                TotalPrice = products.Sum(p => p.Price * (1 - p.Discount / 100m)),
                OrderDate = dto.OrderDate
            };

            var createdOrder = await _orderService.AddAsync(order);

            return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Order order)
        {
            if (id != order.Id)
                return BadRequest();

            await _orderService.UpdateAsync(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteAsync(id);
            return NoContent();
        }
    }
}
