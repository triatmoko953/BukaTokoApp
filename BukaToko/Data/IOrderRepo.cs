using BukaToko.Models;

namespace BukaToko.Data
{
    public interface IOrderRepo
    {
        Task AddToCart(string userId, int itemId, Cart cart);
        Task DeleteFromCart(int id);
        Task UpdateQty(int id,int qty);
        Task Checkout();
        Task<IEnumerable<Order>> GetAllOrderById(int id);
        Task<Order> GetCartListById(int id);
        Task<int> GetIdByUsername(string username);
    }
}
