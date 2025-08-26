using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopHub.PrimaryPorts.Category;
using ShopHub.PrimaryPorts.Category.Models;

namespace Shophub.Server.Controllers.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // why readonly
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
    }
}
