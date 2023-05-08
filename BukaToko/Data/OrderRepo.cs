﻿using BukaToko.DTOS;
using BukaToko.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;


//TODO: kelarin GetAllOrder
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

        public async Task Checkout(int userId)
        {
            var order = await _context.Orders.Where(o => o.UserId==userId && o.Checkout==false ).FirstOrDefaultAsync();
            if (order!=null)
            {
                order.Checkout = true;
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task DeleteFromCart(int userId, int id)
        {

            //check id exist
            var temp = await GetListCartUser(userId);
            if (temp != null)
            {
                var item = temp.Find(o => o.Id == id);
                if (item != null)
                {
                    _context.Carts.Remove(item);
                }
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task<List<Order>?> GetAllOrder()
        {
            throw new NotImplementedException();
            
        }

        public async Task<Cart?> GetCartById(int userId, int id)
        {
            var temp = await GetListCartUser(userId);
            if (temp != null)
            {
                var item = temp.Find(o => o.Id == id);
                if (item != null)
                {
                    return item;
                }
            }
            return null;
        }

        public async Task<List<Cart>?> GetListCartUser(int userId)
        {
            var listItem = await _context.Carts.Where(o => o.Order.UserId == userId && o.Order.Checkout == false).ToListAsync();
            
            if (listItem != null)
            {
                return listItem;
            }
            else return null;
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

        public async Task Shipped(int orderId)
        {
            var order = await _context.Orders.Where(o => o.Shipped == false && o.Checkout == true).FirstOrDefaultAsync();
            if(order != null)
            {
                order.Shipped = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateQty(int userId, int id, int qty)
        {
            var cart = await GetCartById(userId,id);
            if (cart != null)
            {
                cart.Quantity = qty;
                await _context.SaveChangesAsync();
            }
        }
    }
}
