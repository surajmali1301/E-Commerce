using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Mini_Project_DotNet.Models;
using Mini_Project_DotNet.Repository;

namespace Mini_Project_DotNet.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository repo;

        public CartService(ICartRepository repo)
        {
            this.repo = repo;
        }
        public int AddCart(Cart cart)
        {
           return repo.AddCart(cart);
        }

        public Cart GetCart(int cartId)
        {
            return repo.GetCart(cartId);
        }

        public Cart GetCartById(int cartId)
        {
           return repo.GetCartById(cartId);
        }

        public IEnumerable<Cart> GetCartsByUserId(int userId)
        {
            return repo.GetCartsByUserId(userId);
        }

        public int RemoveCart(int cartId)
        {
            return repo.RemoveCart(cartId);
        }

        public int UpdateCart(Cart cart)
        {
            return repo.UpdateCart(cart);
        }
    }
}
