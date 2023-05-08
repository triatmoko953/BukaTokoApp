using BukaToko.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotChocolate.Authorization;
using System.Security.Claims;
using BukaToko.DTO;
using BukaToko.Models;

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

        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
            var tempName = "akun1";
            var userId = await _orderRepo.GetUserId(tempName);
            if (userId == null) return BadRequest("user not found");

            return Ok();
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
        public IActionResult UpdateQty(int CartId, int qty)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFromCart(int CartId)
        {
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
