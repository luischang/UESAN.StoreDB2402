using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UESAN.StoreDB.DOMAIN.Core.DTO;
using UESAN.StoreDB.DOMAIN.Core.Entities;
using UESAN.StoreDB.DOMAIN.Core.Interfaces;

namespace UESAN.StoreDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            //_categoryRepository = categoryRepository;
            _categoryService = categoryService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id, [FromQuery] bool includeProducts)
        {
            if (includeProducts)
                return Ok(await _categoryService.GetCategoryWithProducts(id));

            return Ok(await _categoryService.GetCategoryById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CategoryDescriptionDTO categoryDTO)
        {
            int categoryId = await _categoryService.Insert(categoryDTO);
            return Ok(categoryId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if(id != categoryDTO.Id) return BadRequest();
            var result = await _categoryService.Update(categoryDTO);
            if(!result) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.Delete(id);
            if (!result) return NotFound();
            return Ok(result);
        }

    }
}
