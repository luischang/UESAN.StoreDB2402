using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UESAN.StoreDB.DOMAIN.Infrastructure.Data;

namespace UESAN.StoreDB.API.Controllers
{
    [ApiController]
    [Route("api/mongoproducts")]
    public class MongoProductsController : ControllerBase
    {
        private readonly MongoDbContext _mongoContext;

        public MongoProductsController(MongoDbContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var products = await _mongoContext.Articles.ToListAsync();
            return Ok(products);
        }
    }

}
