using Mini_Project_DotNet.Models;

namespace Mini_Project_DotNet.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Orders> GetAllOrders();

        Orders GetOrderById(int id);

        int AddOrder(Orders order);

        int UpdateOrder(Orders order);

        int DeleteOrder(int id);


    }
}
