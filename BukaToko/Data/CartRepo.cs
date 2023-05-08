using BukaToko.Models;
using Microsoft.EntityFrameworkCore;

namespace BukaToko.Data
{
    public class CartRepo : ICartRepo
    {
        private readonly BukaTokoDbContext _context;

        public CartRepo(BukaTokoDbContext context)
        {
            _context = context;
        }
        public async Task<Cart> CreateCart(Cart cart)
        {
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }

            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return cart;

        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            return await _context.Carts.ToListAsync();
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }

            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();

            return cart;
        }

        public async Task<Cart> GetById(int id)
        {
            return await _context.Carts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
