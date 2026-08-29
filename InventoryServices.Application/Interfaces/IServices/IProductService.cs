using InventoryServices.Application.Dtos.ProductDtos;

namespace InventoryServices.Application.Interfaces.IServices;

public interface IProductService    
{
    Task<ViewProductDto> CreateAsync(CreateProductRequest productRequest, CancellationToken cancellationToken);

    Task<List<ViewProductDto>> GetProductsAsync(CancellationToken cancellationToken);

    Task<ViewProductDto> GetProductAsync(string sku, CancellationToken cancellationToken);

    Task<bool> UpdateProductAsync(UpdateProductRequest productRequest);
    Task<bool> StockAdjustmentAsync(string sku, int stockQty, CancellationToken cancellationToken);
}
    