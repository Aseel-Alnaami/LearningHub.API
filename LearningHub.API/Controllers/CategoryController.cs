using LearningHub.Core.Data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices categoryServices;
         public CategoryController(ICategoryServices categoryServices)
        {
            this.categoryServices = categoryServices;
        }


        [HttpPost]
        public void CreateCategory(Category category)
        {
            categoryServices.CreateCategory(category);
        }

        [HttpDelete]// from Url
        [Route("DeleteCategory/{id}")]
        public void DeleteCategory(int id)
        {
            categoryServices.DeleteCategory(id);
        }

        [HttpGet]
        public List<Category> GetAllCategories()
        {
            return categoryServices.GetAllCategories();
        }

        [HttpGet]
        [Route("GetCategoryById/{id}")]
        public Category GetCategoryById(int id)
        {
            return categoryServices.GetCategoryById(id);
        }

        [HttpPut]
        public void UpdateCategory(Category category)
        {
            categoryServices.UpdateCategory(category);
        }
    }
}
