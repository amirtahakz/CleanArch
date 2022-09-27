using CleanArch.Domain.ProductAgg;
using CleanArch.Domain.ProductAgg.Events;
using CleanArch.Domain.ProductAgg.Repository;
using CleanArch.Domain.Shared;
using CleanArch.Domain.Shared.Exceptions;
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
        private readonly IMediator _mediator;

        public CreateProductCommandHndler(IProductRepository productRepository, IMediator mediator)
        {
            _productRepository = productRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //var validator = new CreateProductCommandValidator();
            //var checker = validator.Validate(request);
            //if (!checker.IsValid)
            //    throw new InvalidDomainDataException(checker.Errors[0].ToString());

            var product = new Product(request.Title , Money.FromTooman(request.Price) , request.Description);
            _productRepository.Add(product);
            await _productRepository.SaveChanges();

            await _mediator.Publish(new ProductCreated(product.Id , product.Title));

            return await Unit.Task;
        }
    }
}
