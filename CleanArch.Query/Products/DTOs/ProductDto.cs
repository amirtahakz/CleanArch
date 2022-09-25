using CleanArch.Domain.ProductAgg;
using CleanArch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Products.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public Money Money { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}
