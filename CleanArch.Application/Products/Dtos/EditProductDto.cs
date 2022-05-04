using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Dtos
{
    public class EditProductDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
    }
}
