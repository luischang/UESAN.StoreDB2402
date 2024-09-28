using UESAN.StoreDB.DOMAIN.Core.DTO;

namespace UESAN.StoreDB.DOMAIN.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<CategoryListDTO>> GetCategories();
        Task<CategoryListDTO> GetCategoryById(int id);
        Task<int> Insert(CategoryDescriptionDTO categoryDTO);
        Task<bool> Update(CategoryDTO categoryDTO);
        Task<CategoryProductsDTO> GetCategoryWithProducts(int id);

    }
}