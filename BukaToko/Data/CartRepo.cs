using BukaToko.Models;

namespace BukaToko.Data
{
    public class CartRepo : ICartRepo
    {
        public Task<Cart> CreateCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cart>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Cart> UpdateCart(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
