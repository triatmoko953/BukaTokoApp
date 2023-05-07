using BukaToko.Data;
using BukaToko.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BukaToko.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepo _cartRepo;

        public CartController(ICartRepo cartRepo)
        {
            _cartRepo = cartRepo;
        }

        [HttpGet]
        public IActionResult GetCart()
        {
            return Ok();
        }
    }
}
