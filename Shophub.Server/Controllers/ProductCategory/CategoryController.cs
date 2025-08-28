using Microsoft.AspNetCore.Mvc;
using ShopHub.PrimaryPorts.ProductCategory;
using ShopHub.PrimaryPorts.ProductCategory.Models;

namespace Shophub.Server.Controllers.ProductCategory
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAdapter _categoryAdapter;
        public CategoryController(ICategoryAdapter categoryAdapter)
        {
            _categoryAdapter = categoryAdapter;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<string>> CreateCategory(CreateCategoryDto categoryDto)
        {
            return await _categoryAdapter.Create(categoryDto);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<string>> UpdateCategory(UpdateCategoryDto categoryDto)
        {
            return await _categoryAdapter.Update(categoryDto);
        }

        [HttpGet]
        [Route("get/{categoryId}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(string categoryId)
        {
            return await _categoryAdapter.Get(categoryId);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<CategoriesDto>> GetAllCategories()
        {
            return await _categoryAdapter.GetAll();
        }

        [HttpDelete]
        [Route("delete/{categoryId}")]
        public async Task<ActionResult<string>> DeleteCategory(string categoryId)
        {
            return await _categoryAdapter.Delete(categoryId);
        }
    }
}
