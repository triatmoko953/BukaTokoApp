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

        public async Task AddToCart(int userId,Cart cart)
        {
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }
            //kalau order belom ada bikin baru
            var order = await _context.Orders.Where(o=>o.UserId == userId && o.Checkout == false).FirstOrDefaultAsync();
            if (order == null)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var tempOrder = new Order
                        {
                            UserId = userId,
                            Checkout = false,
                            Shipped = false
                        };
                        await _context.Orders.AddAsync(tempOrder);

                        var tempCart = new Cart
                        {
                            OrderId = tempOrder.Id,
                            Name = cart.Name,
                            Price = cart.Price,
                            Quantity = cart.Quantity,

                        };
                        await _context.Carts.AddAsync(tempCart);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                    
                }
            }
            else
            {
                var tempCart = new Cart
                {
                    OrderId = order.Id,
                    Name = cart.Name,
                    Price = cart.Price,
                    Quantity = cart.Quantity,

                };
                await _context.Carts.AddAsync(tempCart);
                await _context.SaveChangesAsync();
            }
        }

        public Task Checkout()
        {
            throw new NotImplementedException();

        }

        public async Task DeleteFromCart(int id)
        {
            try
            {
                var cart = await GetCartById(id);
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cart> GetCartById(int id)
        {
            var cart = await _context.Carts.Where(o => o.Id == id).FirstOrDefaultAsync();
            if (cart == null)
            {
                throw new Exception("cart not found");
            }
            return cart;
        }

        public async Task<List<Cart>> GetListCartByOrderId(int id)
        {
            throw new NotImplementedException();
            var order = await _context.Orders.Where(o => o.Id == id).FirstOrDefaultAsync();
            if (order != null)
            {
                var cart = await _context.Carts.Where(o => o.OrderId == order.Id).ToListAsync();
                if (cart != null)
                {
                    return cart;
                }
                else { throw new Exception("cart not found"); }
                
            }
            throw new Exception("cart not found");
            
        }

        public async Task<int> GetUserId(string username)
        {
            //throw new NotImplementedException();
            var user = await _context.Users.Where(o => o.Username == username).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("user not found");
            }
            return user.Id;
        }

        public async Task UpdateQty(int id, int qty)
        {
            try
            {
                var cart = await  GetCartById(id);
                cart.Quantity = qty;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
