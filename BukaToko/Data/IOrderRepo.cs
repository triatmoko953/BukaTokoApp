using BukaToko.Models;

namespace BukaToko.Data
{
    public interface IOrderRepo
    {
       
        Task AddOrder(Order order);
        Task DeleteOrder(int id);
        Task UpdateOrder(Order order);

        Task<IEnumerable<Order>> GetAllOrderById();
        Task<Order> GetOrderById();
    }
}
