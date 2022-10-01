using Api.ViewModels.Products;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class ProductController : Api.Controllers.V1.ProductController
    {
        public ProductController(IMediator mediator , IMapper mapper) : base(mediator , mapper)
        {

        }
        [HttpGet("{id}")]
        public override async Task<ActionResult<ProductVm>> GetProductById(Guid id)
        {
            return new ProductVm();
        }
    }
}
