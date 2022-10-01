using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //private IOrderService _orderService;

        //public OrderController(IOrderService orderService)
        //{
        //    _orderService = orderService;
        //}

        //[HttpGet]
        //public IActionResult GetOrders()
        //{
        //    return Ok(_orderService.GetOrders());
        //}
    }
}
