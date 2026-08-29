using InventoryServices.Application.Dtos.ProductDtos;
using InventoryServices.Application.Interfaces.IRepository;
using InventoryServices.Domain.Constants;
using InventoryServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryServices.Infrastructure.Repository;

public class ProductRepository(InventoryDbContext dbContext) : IProductRepository
{
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        product.InventoryAdjustments.Add(new InventoryAdjustment
        {
            QtyChange = product.Qty,
            CreatedAt = product.CreatedAt,
            Action = StockAdjustments.INITIAL,
        });

        dbContext.Products.Add(product);

        await dbContext.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<Product?> GetProductAsync(string sku, CancellationToken cancellationToken = default)
    {
        return await dbContext.Products.FirstOrDefaultAsync(product => product.Sku == sku, cancellationToken);
    }

    public async Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Products.ToListAsync(cancellationToken);
    }

    public async Task<bool> UpdateAsync(UpdateProductRequest productRequest)
    {
        return await dbContext.Products
                              .Where(product => product.Sku == productRequest.Sku)
                              .ExecuteUpdateAsync(update => update.SetProperty(product => product.Price, productRequest.Price)) > 0;
    }

    public async Task<bool> StockAdjustment(string sku, int stockQty, CancellationToken cancellationToken = default)
    {
        var product = await dbContext.Products.FirstOrDefaultAsync(product => product.Sku == sku, cancellationToken);

        if (product == null)
        {
            return false;
        }

        product.Qty += stockQty;

        var inventoryAdjustment = new InventoryAdjustment
        {
            ProductId = product.Id,
            QtyChange = stockQty,
            Action = stockQty > 0 ? StockAdjustments.STOCKINCREASE : StockAdjustments.STOCKDECREASE,
            CreatedAt = DateTime.UtcNow,
        };
        dbContext.Update(product);
        dbContext.InventoryAdjustments.Add(inventoryAdjustment);
        return await dbContext.SaveChangesAsync(cancellationToken) > 0;

    }

    public async Task<int> StockOnHandCheck(string sku)
    {
        return await dbContext.Products
                              .Where(product => product.Sku == sku)
                              .Select(product => product.Qty).FirstAsync();
    }
}
