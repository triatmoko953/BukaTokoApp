﻿using BukaToko.DTOS;
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
                        await _context.SaveChangesAsync();

                        var t = tempOrder;
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

        public async Task DeleteFromCart(int userId, int id)
        {
            
            //check id exist
            var item = await _context.Carts.Where(o=> o.Order.UserId == userId && o.Id == id).FirstOrDefaultAsync();
            if (item != null)
            {
                _context.Carts.Remove(item);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Cart?> GetCartById(int id)
        {
            var cart = await _context.Carts.Where(o => o.Id == id).FirstOrDefaultAsync();
            if (cart != null)
            {
                return cart;
            }
            return null;
        }

        public async Task<List<ReadCartDto>?> GetListCartUser(int userId)
        {
            var order = await _context.Orders.Where(o => o.UserId == userId && o.Checkout == false).FirstOrDefaultAsync();
            if (order != null)
            {
                var cart = await _context.Carts.Where(o => o.OrderId == order.Id).ToListAsync();
                if (cart != null)
                {
                    var temp = new List<ReadCartDto>();
                    foreach (var item in cart)
                    {
                        temp.Add(new ReadCartDto
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Price = item.Price,
                            Quantity = item.Quantity,
                        });
                    }
                    return temp;
                }
                else { return null; }
            }
            return null;
        }

        public async Task<int?> GetUserId(string username)
        {
            //throw new NotImplementedException();
            var user = await _context.Users.Where(o => o.Username == username).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            return user.Id;
        }

        public async Task UpdateQty(int id, int qty)
        {
            var cart = await GetCartById(id);
            if (cart != null)
            {
                cart.Quantity = qty;
                await _context.SaveChangesAsync();
            }
        }
    }
}
