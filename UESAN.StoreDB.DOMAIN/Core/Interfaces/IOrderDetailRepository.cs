using UESAN.StoreDB.DOMAIN.Core.Entities;

namespace UESAN.StoreDB.DOMAIN.Core.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<bool> Insert(IEnumerable<OrderDetail> orderDetails);
    }
}