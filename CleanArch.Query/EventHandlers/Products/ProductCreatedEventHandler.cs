using CleanArch.Domain.ProductAgg.Events;
using CleanArch.Domain.ProductAgg.Repository;
using CleanArch.Query.Models.Products.Repository;
using CleanArch.Query.Models.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.EventHandlers.Products
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCreated>
    {
        private readonly IProductReadRepository _readRepository;
        private readonly IProductRepository _writeRepository;

        public ProductCreatedEventHandler(IProductReadRepository readRepository, IProductRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {
            var product = await _writeRepository.GetById(notification.Id);
            await _readRepository.Insert(new ProductReadModel()
            {
                Id = notification.Id,
                Description = product.Description,
                Images = null,
                Title = product.Title,
                Money = product.Money,
                CreationDate = product.CreationDate
            });
        }
    }
}
