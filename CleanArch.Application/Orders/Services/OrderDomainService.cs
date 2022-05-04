using CleanArch.Domain.OrderAgg.Services;
using CleanArch.Domain.ProductAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Orders.Services
{
    public class OrderDomainService : IOrderDomainService
    {
        private readonly IProductRepository _productRepository;
        public bool IsProductExist(Guid productId)
        {
            var productIsService = _productRepository.IsProductService(productId);

            return productIsService;
        }
    }
}
