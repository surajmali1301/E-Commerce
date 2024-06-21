using Mini_Project_DotNet.Models;

namespace Mini_Project_DotNet.Services
{
    public interface IOrderService
    {
        IEnumerable<Orders> GetAllOrders();

        Orders GetOrderById(int id);

        int AddOrder(Orders order);

        int UpdateOrder(Orders order);

        int DeleteOrder(int id);
    }
}
