using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Orders.Dtos
{
    public class AddOrderDto
    {
        public Guid ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
