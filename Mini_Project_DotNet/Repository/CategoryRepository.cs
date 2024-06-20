using Mini_Project_DotNet.Data;
using Mini_Project_DotNet.Models;
using NuGet.DependencyResolver;

namespace Mini_Project_DotNet.Repository
{
    public class CategoryRepository : ICategoryRepositry
    {
        private readonly ApplicationDbContext db;

        public CategoryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddCategory(Category category)
        {
            int result = 0;
            db.Category.Add(category);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteCategory(int id)
        {
            int result = 0;
            var model = db.Category.Where(x=>x.CategoryId == id).FirstOrDefault();
            if(model != null)
            {
                result = db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Category> GetCategories()
        {
            var model = (from cat in db.Category
                         select cat).ToList();
            return model;
        }

        public Category GetCategory(int id)
        {
            return db.Category.Where(x => x.CategoryId == id).SingleOrDefault();
        }

        public int UpdateCategory(Category category)
        {
            int result = 0;
            var model = db.Category.Where(x=>x.CategoryId == category.CategoryId).FirstOrDefault();
            if(model != null) 
            {
                model.Name = category.Name;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
