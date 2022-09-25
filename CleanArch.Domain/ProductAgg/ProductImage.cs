using CleanArch.Domain.Shared;
using CleanArch.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.ProductAgg
{
    public class ProductImage : BaseEntity
    {
        private ProductImage()
        {

        }
        public ProductImage(Guid productId, string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, "imageName");

            Id = Guid.NewGuid();
            ProductId = productId;
            ImageName = imageName;
        }

        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public string ImageName { get; private set; }
    }
}
