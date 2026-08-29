using InventoryServices.Application.Dtos.OrderDtos;
using InventoryServices.Application.Interfaces.IRepository;
using InventoryServices.Application.Interfaces.IServices;
using InventoryServices.Application.Mappers;
using InventoryServices.Domain.Constants;
using InventoryServices.Domain.Entities;
using InventoryServices.Domain.GenericResponse;
using Microsoft.Extensions.Logging;

namespace InventoryServices.Application.Services;

public class OrderService(IOrderRepository orderRepository,
                          IProductRepository productRepository,
                          ILogger<OrderService> logger) : IOrderService
{
    public async Task<ResponseMessage> CreateAsync(CreateOrderDto orderDto, CancellationToken cancellationToken)
    {
        logger.LogInformation("OrderService => Attempt to create a new order");
        return await orderRepository.CreateAsync(orderDto, cancellationToken);
    }

    public async Task<bool> AvailableStockCheckAsync(string sku, int orderQy)
    {
        return await productRepository.StockOnHandCheck(sku) >= orderQy;
    }
}
