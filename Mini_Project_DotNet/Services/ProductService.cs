using Mini_Project_DotNet.Models;
using Mini_Project_DotNet.Repository;

namespace Mini_Project_DotNet.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repo;

        public ProductService(IProductRepository repo)
        {
            this.repo = repo;
        }
        public int AddProduct(Product product)
        {
           return repo.AddProduct(product);
        }

        public int DeleteProduct(int id)
        {
            return repo.DeleteProduct(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return repo.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return repo.GetProduct(id);
        }

        public int UpdateProduct(Product product)
        {
            return repo.UpdateProduct(product);
        }
    }
}
