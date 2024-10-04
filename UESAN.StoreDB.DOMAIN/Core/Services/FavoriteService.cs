using UESAN.StoreDB.DOMAIN.Core.DTO;
using UESAN.StoreDB.DOMAIN.Core.Entities;
using UESAN.StoreDB.DOMAIN.Core.Interfaces;

namespace UESAN.StoreDB.DOMAIN.Core.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<IEnumerable<FavoriteListDTO>> GetAll(int userId)
        {
            var favorites = await _favoriteRepository.GetAll(userId);
            if (favorites.Count() == 0)
                return null;
            var favoritesDTO = favorites.Select(favorite => new FavoriteListDTO
            {
                Id = favorite.Id,
                Product = new ProductCategoryDTO
                {
                    Id = favorite.Product.Id,
                    Description = favorite.Product.Description,
                    Price = favorite.Product.Price,
                    Stock = favorite.Product.Stock,
                    Discount = favorite.Product.Discount,
                    ImageUrl = favorite.Product.ImageUrl,
                    Category = new CategoryListDTO
                    {
                        Id = favorite.Product.Category.Id,
                        Description = favorite.Product.Category.Description
                    }
                },
                CreatedAt = favorite.CreatedAt
            }).ToList();

            return favoritesDTO;
        }

        public async Task<bool> Insert(FavoriteInsertDTO favoriteDTO)
        {
            var favorite = new Favorite()
            {
                UserId = favoriteDTO.UserId,
                ProductId = favoriteDTO.ProductId,
                CreatedAt = DateTime.Now
            };

            return await _favoriteRepository.Insert(favorite);
        }

        public async Task<bool> Delete(int id)
        {
            return await _favoriteRepository.Delete(id);
        }
    }
}
