using UESAN.StoreDB.DOMAIN.Core.DTO;

namespace UESAN.StoreDB.DOMAIN.Core.Interfaces
{
    public interface IOrdersService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<OrdersDTO>> GetAllByUser(int userId);
        Task<OrdersUserDTO?> GetById(int id);
        Task<int> Insert(OrdersInsertDTO ordersDTO);
    }
}