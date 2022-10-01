using CleanArch.Domain.ProductAgg;
using CleanArch.Domain.Shared;

namespace Api.ViewModels.Products
{
    public class ProductVm
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Money Money { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public string Description { get; set; }
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
