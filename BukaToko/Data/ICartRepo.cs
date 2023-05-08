using BukaToko.Models;

namespace BukaToko.Data
{
    public interface ICartRepo
    {
        Task<Cart> CreateCart(Cart cart);
        Task<Cart> UpdateCart(Cart cart);
        Task<Cart> GetById(int id);
        Task<IEnumerable<Cart>> GetAll();
        bool SaveChanges();
    }
}
