using CleanArch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.ProductAgg
{
    public class ProductImage : BaseEntity
    {
        public ProductImage(Guid productId, string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                throw new ArgumentNullException(nameof(imageName));

            Id = Guid.NewGuid();
            ProductId = productId;
            ImageName = imageName;
        }

        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public string ImageName { get; private set; }
    }
}
