using BukaToko.Models;

namespace BukaToko.Data
{
    public class OrderRepo : IOrderRepo
    {
        public Task AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrderById()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderById()
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
