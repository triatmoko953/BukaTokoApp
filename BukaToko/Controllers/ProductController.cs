using BukaToko.Data;
using BukaToko.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BukaToko.Models;

namespace BukaToko.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _product;
        private readonly IMapper _mapper;
        //private readonly IMessageBusClient _messageBusClient;
        public ProductController(IProductRepo productRepo, IMapper mapper)
        {
            _product = productRepo;
            _mapper = mapper;
            //_messageBusClient = messageBusClient;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {

            var product = _mapper.Map<Product>(createProductDto);
            _product.Create(product);
            _product.SaveChanges();

            var readProductDto = _mapper.Map<ReadProductDto>(product);

            return Ok(product);
        }
    }
}
