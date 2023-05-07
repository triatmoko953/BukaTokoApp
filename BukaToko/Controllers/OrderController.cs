using BukaToko.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotChocolate.Authorization;
using System.Security.Claims;

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
        public IActionResult GetOrder()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddToCart()
        {
            return Ok();
        }
        [HttpPost("{id}")]
        public IActionResult UpdateQty(int CartId, int qty)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFromCart(int CartId)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult ShippedOrder(int OrderId)
        {
            return Ok();
        }

    }
}
