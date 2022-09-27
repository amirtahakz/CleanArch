using CleanArch.Application.Products.Create;
using CleanArch.Application.Products.Edit;
using CleanArch.Query.Models.Products;
using CleanArch.Query.Products.DTOs;
using CleanArch.Query.Products.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _mediator.Send(command);
            // Or
            //await _mediator.Send(new CreateProductCommand(command.Title, command.Price));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditProduct(EditProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<List<ProductReadModel>> GetProductList()
        {
            return await _mediator.Send(new GetProductListQuery());
        }
    }
}
