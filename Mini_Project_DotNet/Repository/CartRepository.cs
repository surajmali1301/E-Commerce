using Microsoft.EntityFrameworkCore;
using Mini_Project_DotNet.Data;
using Mini_Project_DotNet.Models;

namespace Mini_Project_DotNet.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext db;

        public CartRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Cart> GetCartsByUserId(int userId)
        {
            return db.Cart.Where(c => c.UserId == userId).ToList();
        }

        public Cart GetCart(int cartId)
        {
            return db.Cart.SingleOrDefault(c => c.CartId == cartId);
        }

        public int AddCart(Cart cart)
        {
            db.Cart.Add(cart);
            return db.SaveChanges();
        }

        public int UpdateCart(Cart cart)
        {
            db.Cart.Update(cart);
            return db.SaveChanges();
        }

        public int RemoveCart(int cartId)
        {
            var cart = db.Cart.SingleOrDefault(c => c.CartId == cartId);
            if (cart != null)
            {
                db.Cart.Remove(cart);
                return db.SaveChanges();
            }
            return 0;
        }

        public Cart GetCartById(int cartId)
        {
            return db.Cart.FirstOrDefault(c => c.CartId == cartId);
        }
    }
}
