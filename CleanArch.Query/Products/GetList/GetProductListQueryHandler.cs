using CleanArch.Domain.ProductAgg;
using CleanArch.Infrastructure.Persistent.Ef;
using CleanArch.Query.Products.DTOs;
using CleanArch.Query.Products.GetById;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Products.GetList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetProductListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.Include(c => c.Images).Select(product => ProductMapper.MapProductToDto(product)).ToListAsync();
        }
    }

}
