using Mini_Project_DotNet.Models;
using Mini_Project_DotNet.Repository;

namespace Mini_Project_DotNet.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepositry repo;

        public CategoryService(ICategoryRepositry repo)
        {
            this.repo = repo;
        }
        public int AddCategory(Category category)
        {
            return repo.AddCategory(category);
        }

        public int DeleteCategory(int id)
        {
             return repo.DeleteCategory(id);
        }

        public IEnumerable<Category> GetCategories()
        {
           return repo.GetCategories();
        }

        public Category GetCategory(int id)
        {
            return repo.GetCategory(id);
        }

        public int UpdateCategory(Category category)
        {
            return repo.UpdateCategory(category);
        }
    }
}
