using UESAN.StoreDB.DOMAIN.Core.Entities;

namespace UESAN.StoreDB.DOMAIN.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
    }
}