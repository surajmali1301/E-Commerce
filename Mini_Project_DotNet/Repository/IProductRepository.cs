using Mini_Project_DotNet.Models;

namespace Mini_Project_DotNet.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        int AddProduct(Product product);
        int UpdateProduct(Product product);
        int DeleteProduct(int id);
        Product GetProduct(int id);
    }
}
