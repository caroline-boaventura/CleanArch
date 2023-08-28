using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(int? id);
    Task<Product> GetProductByCategoryAsync(int? categoryId);
    Task<Product> CreateAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<Product> RemoveAsync(Product product);
}
