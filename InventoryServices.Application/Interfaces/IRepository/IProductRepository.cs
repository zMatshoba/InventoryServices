using InventoryServices.Application.Dtos.ProductDtos;
using InventoryServices.Domain.Entities;

namespace InventoryServices.Application.Interfaces.IRepository;

public interface IProductRepository
{
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);
    Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken = default);
    Task<Product?> GetProductAsync(string sku, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(UpdateProductRequest productRequest);
    Task<bool> StockAdjustment(string sku, int stockQty, CancellationToken cancellationToken = default);
    Task<int> StockOnHandCheck(string sku);
}
