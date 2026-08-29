using InventorySystem.MVC.Configuration;
using InventorySystem.MVC.Models;
using InventorySystem.MVC.Services.HttpService;
using Microsoft.Extensions.Options;

namespace InventorySystem.MVC.Services
{
    public class ProductService(IHttpClientService clientService,
                                IOptionsSnapshot<ApiEndpoints> options) : IProductService
    {
        public async Task<List<ProductModel>> GetProductsAsync()
        {
            var route = options.Value.GetProducts;

            return await clientService.HttpRetrieveAllAsync<ProductModel>(route);
        }

        public async Task<ProductModel> GetProduct(string sku)
        {
            var route = options.Value.GetProduct.Replace("{sku}", sku);

            return await clientService.HttpRetrieveByIdAsync<ProductModel>(route);
        }
    }
}
