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

    public async Task<Product> GetById(Guid id)
    {
        var res =_context.Products.FirstOrDefault(f => f.Id == id);
        return await Task.FromResult(res);
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
    }

    public async Task Update(Product product)
    {
        var oldProduct = await GetById(product.Id);
        _context.Products.Remove(oldProduct);
        Add(product);
    }

    public void Remove(Product product)
    {
        _context.Products.Remove(product);
    }

    public async Task SaveChanges()
    {
        //
    }

    public bool IsProductService(Guid id)
    {
        return _context.Products.Any(f => f.Id == id);
    }
}