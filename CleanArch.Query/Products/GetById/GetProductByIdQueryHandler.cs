using CleanArch.Infrastructure.Persistent.Ef;
using CleanArch.Query.Models.Products.Repository;
using CleanArch.Query.Models.Products;
using CleanArch.Query.Products.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Query.Products.GetById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductReadModel>
    {
        private IProductReadRepository _readRepository;

        public GetProductByIdQueryHandler(IProductReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<ProductReadModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _readRepository.GetById(request.ProductId);
        }
    }
}
