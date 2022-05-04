using CleanArch.Application.Products.Dtos;
using CleanArch.Domain.ProductAgg;
using CleanArch.Domain.ProductAgg.Repository;
using CleanArch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public void AddProduct(AddProductDto command)
        {
            _repository.Add(new Product(command.Title , Money.FromTooman(command.Price)));
        }

        public void EditProduct(EditProductDto command)
        {
            var product = _repository.GetById(command.Id);
            product.Edit(command.Title , Money.FromTooman(command.Price));

            _repository.Update(product);
        }

        public ProductDto GetProductById(Guid productId)
        {
            var product = _repository.GetById(productId);
            return new ProductDto()
            {
                Price = product.Price.Value,
                Id = productId,
                Title = product.Title
            };
        }

        public List<ProductDto> GetProducts()
        {
            return _repository.GetAll().Select(product => new ProductDto()
            {
                Price = product.Price.Value,
                Id = product.Id,
                Title = product.Title
            }).ToList();

        }
    }
}
