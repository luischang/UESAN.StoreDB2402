using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.StoreDB.DOMAIN.Core.Entities;
using UESAN.StoreDB.DOMAIN.Core.Interfaces;
using UESAN.StoreDB.DOMAIN.Infrastructure.Data;

namespace UESAN.StoreDB.DOMAIN.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;

        public CategoryRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }       

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _dbContext.Category.Where(c=>c.IsActive==true).ToListAsync();
            return categories;
        }

        //Get Category by ID
        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _dbContext
                    .Category
                    .Where(c => c.Id == id && c.IsActive == true)
                    .FirstOrDefaultAsync();
            return category;
        }

        public async Task<Category> GetCategoryWithProducts(int id)
        {
            var category = await _dbContext
                        .Category
                        .Where(c => c.Id == id && c.IsActive == true)
                        .Include(p=>p.Product)
                        .FirstOrDefaultAsync();
            return category;
        }

        //Create category
        public async Task<int> Insert(Category category)
        {
            category.IsActive = true;
            await _dbContext.Category.AddAsync(category);
            int rows = await _dbContext.SaveChangesAsync();

            return rows > 0 ? category.Id : -1;
        }

        //Update category
        public async Task<bool> Update(Category category)
        {
            _dbContext.Category.Update(category);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        //Delete category
        public async Task<bool> Delete(int id)
        {
            var category = await _dbContext
                            .Category
                            .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return false;

            category.IsActive = false;
            int rows = await _dbContext.SaveChangesAsync();
            return (rows > 0);

            //_dbContext.Category.Remove(category);

        }




    }
}
