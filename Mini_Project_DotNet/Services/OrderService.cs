using Mini_Project_DotNet.Data;
using Mini_Project_DotNet.Models;
using Mini_Project_DotNet.Repository;

namespace Mini_Project_DotNet.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repo;
        

        public OrderService(IOrderRepository repo)
        {
            this.repo = repo;
           
        }
      
        public int AddOrder(Orders order)
        {
            return repo.AddOrder(order);
        }

        public int DeleteOrder(int id)
        {
            return repo.DeleteOrder(id);
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            return repo.GetAllOrders();
        }

        public Orders GetOrderById(int id)
        {
            return repo.GetOrderById(id);
        }

        public int UpdateOrder(Orders order)
        {
            return repo.UpdateOrder(order);
        }
    }
}
