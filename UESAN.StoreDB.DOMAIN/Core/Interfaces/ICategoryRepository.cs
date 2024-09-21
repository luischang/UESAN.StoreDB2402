using UESAN.StoreDB.DOMAIN.Core.Entities;

namespace UESAN.StoreDB.DOMAIN.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task<int> Insert(Category category);
        Task<bool> Update(Category category);
    }
}