﻿using BukaToko.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotChocolate.Authorization;
using System.Security.Claims;
using BukaToko.DTO;
using BukaToko.Models;
using BukaToko.DTOS;
using Microsoft.EntityFrameworkCore.Metadata;


//TODO: ganti tempname sama user dari jwt nanti
//TODO: ganti input nama barang dengan nama dari id produk di AddCart()


namespace BukaToko.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo _orderRepo;

        public OrderController(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }



        //list order buat manager
        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
            //var tempName = "akun1";
            //var userId = await _orderRepo.GetUserId(tempName);
            //if (userId == null) return BadRequest("user not found");

            //var listCart = await _orderRepo.GetListCartUser(userId.Value);
            //return Ok(listCart);
            return Ok();
        }

        [HttpGet("Cart")]
        public async Task<IActionResult> GetCart()
        {
            var tempName = "akun1";
            var userId = await _orderRepo.GetUserId(tempName);
            if (userId == null) return NotFound("user not found");

            var listCart = await _orderRepo.GetListCartUser(userId.Value);
            if (listCart == null) return Ok(null);

            var temp = new List<ReadCartDto>();
            foreach (var item in listCart)
            {
                temp.Add(new ReadCartDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                });
            }
            return Ok(temp);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId,int qty)
        {
            
            var tempName = "akun1";
            var userId = await _orderRepo.GetUserId(tempName);
            if (userId == null) return BadRequest("user not found");

            //pake userId.Value karna return nya nullable.
            //cant convert int? -> int
            await _orderRepo.AddToCart(userId.Value, new Cart { Name = "laptop", Price = 500, Quantity = 1 });
            return Ok();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQty(int id, int qty)
        {
            var cart = await _orderRepo.GetCartById(id);
            if (cart == null) return BadRequest("Cart not found");

            await _orderRepo.UpdateQty(cart.Id, qty);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFromCart(int id)
        {
            var tempName = "akun1";
            var userId = await _orderRepo.GetUserId(tempName);
            if (userId == null) return BadRequest("user not found");

            var cart = await _orderRepo.GetCartById(id);
            if (cart == null) return BadRequest("Cart not found");

            await _orderRepo.DeleteFromCart(userId.Value,cart.Id);
            return Ok();
        }

        //[HttpGet()]
        //public IActionResult Checkout()
        //{
        //    return Ok();
        //}

        //[HttpGet]
        //public IActionResult ShippedOrder(int OrderId)
        //{
        //    return Ok();
        //}

    }
}
