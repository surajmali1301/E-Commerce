using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_Project_DotNet.Models;
using Mini_Project_DotNet.Services;
using static NuGet.Packaging.PackagingConstants;

namespace Mini_Project_DotNet.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        // GET: OrdersController
        public ActionResult OrderList()
        {
            var orderList = orderService.GetAllOrders();
            return View(orderList);
        }


        
        public ActionResult PlaceOrder()
        {
            return View();
        }


        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlaceOrder(Orders orders)
        {
            try
            {
                int result = orderService.AddOrder(orders);
                if(result>=1)
                {
                return RedirectToAction(nameof(OrderList));
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

        // GET: OrdersController/Edit/5
        public ActionResult UpdateOrder(int id)
        {
            var order = orderService.GetOrderById(id);
            return View(order);
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateOrder(Orders orders)
        {
            try
            {
                int result = orderService.UpdateOrder(orders);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(OrderList));
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

        // GET: OrdersController/Delete/5
        public ActionResult Delete(int id)
        {
            var order = orderService.GetOrderById(id);
            return View(order);
        }

        // POST: OrdersController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, IFormCollection collection)
        {
            try
            {
                int result = orderService.DeleteOrder(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(OrderList));
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
