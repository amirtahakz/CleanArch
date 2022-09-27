using CleanArch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.ProductAgg.Events
{
    public class ProductEdited : BaseDomainEvent
    {
        public Guid ProductId { get; set; }
        public string Title { get; set; }
    }
}
