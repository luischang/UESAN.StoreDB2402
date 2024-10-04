using UESAN.StoreDB.DOMAIN.Core.Entities;
using UESAN.StoreDB.DOMAIN.Core.Interfaces;
using UESAN.StoreDB.DOMAIN.Infrastructure.Data;

namespace UESAN.StoreDB.DOMAIN.Infrastructure.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly StoreDbContext _dbContext;
        public OrderDetailRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Insert(IEnumerable<OrderDetail> orderDetails)
        {
            await _dbContext.OrderDetail.AddRangeAsync(orderDetails);
            decimal totalAmount = (decimal)orderDetails.Sum(od => od.Quantity * od.Price);
            var order = await _dbContext.Orders.FindAsync(orderDetails.First().OrdersId);
            order.TotalAmount = totalAmount;
            _dbContext.Orders.Update(order);
            int countRows = await _dbContext.SaveChangesAsync();
            return countRows > 0;
        }
    }
}
