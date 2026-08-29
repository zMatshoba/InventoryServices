using InventoryServices.Application.Dtos.ProductDtos;
using InventoryServices.Application.Interfaces.IRepository;
using InventoryServices.Application.Interfaces.IServices;
using InventoryServices.Application.Mappers;
using InventoryServices.Domain.Constants;
using InventoryServices.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace InventoryServices.Application.Services;

public class ProductService(IProductRepository productRepository,
                            ILogger<ProductService> logger) : IProductService
{
    public async Task<ViewProductDto> CreateAsync(CreateProductRequest productRequest, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("ProductService => Attempt to create new product");

            var result = await productRepository.CreateAsync(productRequest.ToEntity(), cancellationToken);

            if (result.Id == 0)
            {
                logger.LogError("{Announcement} => Attempt top create new product failed.", LoggerConstants.FAILED);
                return result.ToModel();
            }

            logger.LogInformation("{Announcement} => Product successfully created", LoggerConstants.SUCCESSFUL);
            return result.ToModel();
        }
        catch (Exception ex)
        {
            logger.LogError(ex,
                            "{Announcemnent} => Attempt to create a Product failed.",
                            LoggerConstants.FAILED);
            return new ViewProductDto();
        }
    }

    public async Task<ViewProductDto> GetProductAsync(string sku, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("ProductService => Attempt to get product by sku");

            var result = await productRepository.GetProductAsync(sku, cancellationToken);

            if (result is null)
            {
                logger.LogWarning("{Announcement} => No product was found with sku {SKU}.", LoggerConstants.WARNING, sku);
                return new ViewProductDto();
            }

            return result.ToModel();

        }
        catch (Exception ex)
        {
            logger.LogError(ex,
                            "{Announcement} => Attempt to get product {SKU} failed.",
                            LoggerConstants.FAILED, sku);
            return new ViewProductDto();
        }
    }

    public async Task<List<ViewProductDto>> GetProductsAsync(CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("ProductService => Attempt to get all products");

            var result = await productRepository.GetProductsAsync(cancellationToken);

            return result.Count > 0 ? [.. result.Select(product => product.ToModel())] : [];

        }
        catch (Exception ex)
        {
            logger.LogError(ex,
                            "{Announcement} => Attempt to get all products failed",
                            LoggerConstants.FAILED);
            return [];
        }
    }

    public async Task<bool> UpdateProductAsync(UpdateProductRequest productRequest)
    {
        try
        {
            logger.LogInformation("ProductService => Attempt to update a product");

            return await productRepository.UpdateAsync(productRequest);

        }
        catch (Exception ex)
        {
            logger.LogError(ex,
                            "{Announcement} => Attempt to update product {SKU} failed",
                            LoggerConstants.FAILED, productRequest.Sku);
            throw;
        }
    }

    public async Task<bool> StockAdjustmentAsync(string sku,int stockQty,CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("ProductService => Attempt to adjust stock qty");

            return await productRepository.StockAdjustment(sku, stockQty, cancellationToken);

        }
        catch (Exception ex)
        {
            logger.LogError(ex,
                            "{Announcement} => Attempt to adjust stock qty for sku {SKU} failed",
                            LoggerConstants.FAILED, sku);
            return false;
        }
    }

}
