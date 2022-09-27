using CleanArch.Domain.ProductAgg;
using CleanArch.Infrastructure.Persistent.Ef;
using CleanArch.Query.Models.Products.Repository;
using CleanArch.Query.Models.Products;
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
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductReadModel>>
    {
        private IProductReadRepository _readRepository;

        public GetProductListQueryHandler(IProductReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<List<ProductReadModel>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return await _readRepository.GetAll();
        }
    }

}
