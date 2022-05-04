using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Orders.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
