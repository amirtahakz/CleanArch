using CleanArch.Domain.ProductAgg;
using CleanArch.Domain.Shared;


namespace CleanArch.Domain.XUnit.Tests.Builders
{
    internal class ProductBuilder
    {
        private string _title = "test";
        private Money _money = new Money(1000000);
        private ICollection<ProductImage> _images;

        public ProductBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }

        public ProductBuilder SetMoney(int rialValue)
        {
            _money = new Money(rialValue);
            return this;
        }
        public ProductBuilder SetImage(ProductImage image)
        {
            _images.Add(image);
            return this;
        }
        public Product Build()
        {
            return new Product(_title, _money);
        }
    }
}
