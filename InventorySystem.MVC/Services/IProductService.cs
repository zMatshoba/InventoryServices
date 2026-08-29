using InventorySystem.MVC.Models;

namespace InventorySystem.MVC.Services;

public interface IProductService
{
    Task<ProductModel> GetProduct(string sku);
    Task<List<ProductModel>> GetProductsAsync();
}
