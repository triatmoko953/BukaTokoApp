using BukaToko.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace BukaToko.Data
{
    public class OrderRepo : IOrderRepo
    {
        private readonly BukaTokoDbContext _context;

        public OrderRepo(BukaTokoDbContext context)
        {
            _context = context;
        }

        public async Task AddToCart(string userId,int itemId,Cart cart)
        {
            //jangan lupa lepas
            throw new NotImplementedException();


            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }
            var order = await _context.Orders.Where(o=>o.CartId == itemId && o.Checkout == false).FirstOrDefaultAsync();
            if (order == null)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    await _context.Carts.AddAsync(cart);
                    
                }
            }
        }

        public Task Checkout()
        {
            throw new NotImplementedException();
        }

        public Task DeleteFromCart(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetCartListById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetIdByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task UpdateQty(int id, int qty)
        {
            throw new NotImplementedException();
        }
    }
}
