using Mini_Project_DotNet.Models;

namespace Mini_Project_DotNet.Repository
{
    public interface ICategoryRepositry
    {
        IEnumerable<Category> GetCategories();

        int AddCategory(Category category);

        int UpdateCategory(Category category);

        int DeleteCategory(int id);

        Category GetCategory(int id);
    }
}
