using CleanArch.Application.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Products
{
    public interface IProductService
    {
        void AddProduct(AddProductDto command);
        void EditProduct(EditProductDto command);
        ProductDto GetProductById(Guid productId);
        List<ProductDto> GetProducts();
    }
}
