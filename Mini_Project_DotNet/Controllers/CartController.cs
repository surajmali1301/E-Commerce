using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_Project_DotNet.Models;
using Mini_Project_DotNet.Services;
using System.Security.Claims;

namespace Mini_Project_DotNet.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly IProductService productService;

        public CartController(ICartService cartService, IProductService productService)
        {
            this.cartService = cartService;
            this.productService = productService;
        }

        public ActionResult CartIndex()
        {
            var userId = GetUserIdFromClaims();
            var carts = cartService.GetCartsByUserId(userId);
            foreach (var cart in carts)
            {
                cart.Products = productService.GetProduct(cart.ProductId);
            }
            return View(carts);
        }


        public ActionResult AddToCart()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(int productId, int quantity)
        {
            var userId = GetUserIdFromClaims();
            var product = productService.GetProduct(productId);
            var cart = new Cart
            {
                UserId = (int)userId,
                ProductId = productId,
                Quantity = quantity,
                Price = product.Price,
                Image = product.Image
            };
            if (product.Price == null || product.Image == null)
            {
                // Handle case where product details are not complete
                throw new System.Exception("Product details are incomplete");
            }

            cartService.AddCart(cart);
            return RedirectToAction("CartIndex");
        }

        private int GetUserIdFromClaims()
        {
            var userIdClaim = User.FindFirst("UserId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
            {
                throw new System.Exception("User ID claim is null or empty");
            }

            return int.Parse(userIdClaim);
        }

        public ActionResult Edit(int id)
        {
            var model = cartService.GetCartById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cart cart)
        {
            try
            {
               
                 var model = cartService.UpdateCart(cart);
                if (model != null)
                {
                    return RedirectToAction(nameof(CartIndex));
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong";
                    return View();
                }

                
                
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var model = cartService.GetCartById(id);
            return View(model);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, IFormCollection collection)
        {
            try
            {

                var model = cartService.RemoveCart(id);
                if (model != null)
                {
                    return RedirectToAction(nameof(CartIndex));
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
