using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpPut("{id}")]
        public IActionResult RetractTheOffer(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            _productService.RetractTheOffer(productId, userId);
            return Ok();
        }

        [HttpPut("sellproduct/{id}")]
        public IActionResult SellProduct(int productId, double price)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            _productService.SellProduct(productId, userId, price);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel product)
        {
            _productService.Create(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Create(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}
