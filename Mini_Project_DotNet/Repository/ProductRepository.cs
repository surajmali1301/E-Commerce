using Mini_Project_DotNet.Data;
using Mini_Project_DotNet.Models;

namespace Mini_Project_DotNet.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext db;

        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddProduct(Product product)
        {
            int result = 0;
            db.Products.Add(product);
            result=db.SaveChanges();
            return result;
        }

        public int DeleteProduct(int id)
        {
            int result = 0;
            var model = db.Products.Where(x=>x.ProductId==id).FirstOrDefault();
            if(model!=null)
            {
                result = db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                var model = (from product in db.Products
                             select product).ToList();
                return model;
            }
            catch (Exception ex)
            {
                // Handle database-related exceptions
                // Log the detailed exception message for debugging purposes
                Console.WriteLine($"SQL Error: {ex.Message}");

                // Optionally rethrow the exception or handle it as needed
                throw new Exception("An error occurred while retrieving the products from the database.", ex);
            }
        }


        public Product GetProduct(int id)
        {
            return db.Products.Where(x=>x.ProductId==id).FirstOrDefault();
        }

        public int UpdateProduct(Product product)
        {
            int result = 0;
            var model = db.Products.Where(x=>x.ProductId==product.ProductId).FirstOrDefault();
            if (model!=null)
            {
                model.Image = product.Image;
                model.Name=product.Name;
                model.Price = product.Price;
                model.Description=product.Description;
                model.Quantity = product.Quantity;
                model.CategoryId=product.CategoryId;

                result = db.SaveChanges();
            }

            return result;
        }
    }
}
