using UESAN.StoreDB.DOMAIN.Core.DTO;

namespace UESAN.StoreDB.DOMAIN.Core.Interfaces
{
    public interface IFavoriteService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<FavoriteListDTO>> GetAll(int userId);
        Task<bool> Insert(FavoriteInsertDTO favoriteDTO);
    }
}