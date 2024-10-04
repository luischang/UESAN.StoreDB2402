using UESAN.StoreDB.DOMAIN.Core.DTO;

namespace UESAN.StoreDB.DOMAIN.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductCategoryDTO>> GetAll();
    }
}