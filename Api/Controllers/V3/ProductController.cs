using Api.ViewModels.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V3
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("3.0")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public List<ProductVm> GetProducts()
        {
            var products = new List<ProductVm>();
            return products;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CraeteProduct()
        {
            return Created("123", 1);
        }

        [HttpPut]
        public async Task<IActionResult> EditProduct()
        {
            return Ok();
        }
    }
}
