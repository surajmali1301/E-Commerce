using Mini_Project_DotNet.Models;

namespace Mini_Project_DotNet.Repository
{
    public interface ICartRepository
    {
        IEnumerable<Cart> GetCartsByUserId(int userId);
        Cart GetCart(int cartId);
        int AddCart(Cart cart);
        int UpdateCart(Cart cart);
        int RemoveCart(int cartId);

        Cart GetCartById(int cartId);

    }
}
