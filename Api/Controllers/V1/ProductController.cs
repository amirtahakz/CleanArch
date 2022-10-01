using Api.ViewModels.Products;
using AutoMapper;
using CleanArch.Application.Products.Create;
using CleanArch.Application.Products.Edit;
using CleanArch.Query.Models.Products;
using CleanArch.Query.Products.DTOs;
using CleanArch.Query.Products.GetById;
using CleanArch.Query.Products.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMediator _mediator;
        IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public virtual async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var res = await _mediator.Send(command);
            // Or
            //await _mediator.Send(new CreateProductCommand(command.Title, command.Price));
            var url = Url.Action(nameof(GetProductById), "ProductController", new { id = res }, Request.Scheme);
            return Created(url, res);
        }

        [HttpPut]
        public virtual async Task<IActionResult> EditProduct(EditProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public virtual async Task<ActionResult<List<ProductVm>>> GetProductList()
        {
            var products = await _mediator.Send(new GetProductListQuery());
            return _mapper.Map<List<ProductVm>>(products).AddLinks();
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<ProductVm>> GetProductById(Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product == null)
                return NotFound("product not found");

            return _mapper.Map<ProductVm>(product).AddLinks();
        }

        [HttpDelete]
        public virtual async Task<IActionResult> DeleteProduct(Guid id)
        {
            //
            return Ok();
        }
    }
}
