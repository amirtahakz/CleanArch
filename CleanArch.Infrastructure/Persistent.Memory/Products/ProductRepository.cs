using CleanArch.Domain.ProductAgg;
using CleanArch.Domain.ProductAgg.Repository;

namespace CleanArch.Infrastructure.Persistent.Memory.Products;

public class ProductRepository : IProductRepository
{
    private Context _context;
    public ProductRepository(Context context)
    {
        _context = context;
    }
    public List<Product> GetAll()
    {
        return _context.Products;
    }

    public Product GetById(Guid id)
    {
        return _context.Products.FirstOrDefault(f => f.Id == id);
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
    }

    public void Update(Product product)
    {
        var oldProduct = GetById(product.Id);
        _context.Products.Remove(oldProduct);
        Add(product);
    }

    public void Remove(Product product)
    {
        _context.Products.Remove(product);
    }

    public void Save()
    {
        //
    }

    public bool IsProductService(Guid id)
    {
        return _context.Products.Any(f => f.Id == id);
    }
}