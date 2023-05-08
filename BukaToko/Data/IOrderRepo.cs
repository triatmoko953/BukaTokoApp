﻿using BukaToko.DTOS;
using BukaToko.Models;

namespace BukaToko.Data
{
    public interface IOrderRepo
    {
        Task AddToCart(int userId, Cart cart);
        Task DeleteFromCart(int userId,int id);
        Task UpdateQty(int id,int qty);
        Task Checkout();
        Task<int?> GetUserId(string username);
        Task<Cart?> GetCartById(int id);
        Task<List<ReadCartDto>?> GetListCartUser(int userId);
    }
}
