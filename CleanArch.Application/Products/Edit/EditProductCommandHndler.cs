using CleanArch.Domain.ProductAgg;
using CleanArch.Domain.ProductAgg.Repository;
using CleanArch.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Edit
{
    public class EditProductCommandHndler : IRequestHandler<EditProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public EditProductCommandHndler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            product.Edit(request.Title, Money.FromTooman(request.Price));
            _productRepository.Update(product);
            await _productRepository.SaveChanges();

            return Unit.Value;
        }
    }
}
