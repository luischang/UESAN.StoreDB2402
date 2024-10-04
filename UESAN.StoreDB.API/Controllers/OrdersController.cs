using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.StoreDB.DOMAIN.Core.DTO;
using UESAN.StoreDB.DOMAIN.Core.Interfaces;

namespace UESAN.StoreDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet("OrdersByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var orders = await _ordersService.GetAllByUser(userId);
            if (orders == null)
                return NotFound();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _ordersService.GetById(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(OrdersInsertDTO orders)
        {
            var result = await _ordersService.Insert(orders);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ordersService.Delete(id);
            if (!result) return NotFound();
            return NoContent();

        }
    }
}
