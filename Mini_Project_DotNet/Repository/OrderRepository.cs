using Mini_Project_DotNet.Data;
using Mini_Project_DotNet.Models;

namespace Mini_Project_DotNet.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext db;

        public OrderRepository(ApplicationDbContext db)
        {
            this.db = db;

        }
        public int AddOrder(Orders order)
        {
            order.OrderId = GenerateOrderId();
            order.OrderDate = DateTime.Now;
           
            db.Orders.Add(order);
            return db.SaveChanges();
        }
        private int GenerateOrderId()
        {
            // Example: Generating an order ID based on current date and time
            // You can adjust this logic based on your specific requirements
            string dateString = DateTime.Now.ToString("yyMMddHHmmss");
            string randomNumber = new Random().Next(1000, 9999).ToString(); // Random 4-digit number
            string orderIdString = dateString + randomNumber;

            // Convert to integer
            if (int.TryParse(orderIdString, out int orderId))
            {
                return orderId;
            }
            else
            {
                throw new Exception("Failed to generate Order ID.");
            }
        }


        public int DeleteOrder(int id)
        {
            var orders = db.Orders.SingleOrDefault(o=>o.OrderId == id);
            if(orders!=null)
            {
                db.Orders.Remove(orders);
                return db.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            return db.Orders.ToList();
        }

        public Orders GetOrderById(int id)
        {
            return db.Orders.FirstOrDefault(o=>o.OrderId==id);
        }

        public int UpdateOrder(Orders order)
        {
           db.Orders.Update(order);
            return db.SaveChanges();
        }
    }
}
