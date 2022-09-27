using CleanArch.Domain.ProductAgg.Events;
using CleanArch.Domain.ProductAgg.Repository;
using CleanArch.Query.Models.Products.Repository;
using CleanArch.Query.Models.Products;
using MediatR;

namespace CleanArch.Query.EventHandlers.Products
{
    public class ProductEditedEventHandler : INotificationHandler<ProductEdited>
    {
        private readonly IProductReadRepository _readRepository;
        private readonly IProductRepository _writeRepository;

        public ProductEditedEventHandler(IProductReadRepository readRepository, IProductRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task Handle(ProductEdited notification, CancellationToken cancellationToken)
        {
            var product = await _writeRepository.GetById(notification.ProductId);
            await _readRepository.Update(new ProductReadModel()
            {
                Id = notification.ProductId,
                Description = product.Description,
                Images = product.Images,
                Title = product.Title,
                Money = product.Money,
                CreationDate = product.CreationDate
            });
        }
    }
}
