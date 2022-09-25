using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
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
