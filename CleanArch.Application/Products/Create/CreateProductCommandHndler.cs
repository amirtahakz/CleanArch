using CleanArch.Domain.ProductAgg;
using CleanArch.Domain.ProductAgg.Repository;
using CleanArch.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Create
{
    public class CreateProductCommandHndler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHndler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Title , Money.FromTooman(request.Price));
            _productRepository.Add(product);
            await _productRepository.SaveChanges();

            return await Unit.Task;
        }
    }
}
