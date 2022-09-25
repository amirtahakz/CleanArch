using CleanArch.Infrastructure.Persistent.Ef;
using CleanArch.Query.Products.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Query.Products.GetById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly ApplicationDbContext _context;

        public GetProductByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x=>x.Id == request.ProductId);
            return ProductMapper.MapProductToDto(product);
        }
    }
}
