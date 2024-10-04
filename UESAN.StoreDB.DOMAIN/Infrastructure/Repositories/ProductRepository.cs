using Microsoft.EntityFrameworkCore;
using UESAN.StoreDB.DOMAIN.Core.Entities;
using UESAN.StoreDB.DOMAIN.Core.Interfaces;
using UESAN.StoreDB.DOMAIN.Infrastructure.Data;

namespace UESAN.StoreDB.DOMAIN.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;

        public ProductRepository(StoreDbContext storeDbContext)
        {
            _dbContext = storeDbContext;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext
                            .Product
                            .Where(x => x.IsActive == true)
                            .Include(z => z.Category)
                            .ToListAsync();
        }
    }
}
