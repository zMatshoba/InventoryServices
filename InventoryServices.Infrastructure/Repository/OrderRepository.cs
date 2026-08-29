using InventoryServices.Application.Dtos.OrderDtos;
using InventoryServices.Application.Interfaces.IRepository;
using InventoryServices.Domain.Constants;
using InventoryServices.Domain.Entities;
using InventoryServices.Domain.GenericResponse;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InventoryServices.Infrastructure.Repository;

public class OrderRepository(InventoryDbContext dbContext,
                             ILogger<OrderRepository> logger) : IOrderRepository
{
    public async Task<ResponseMessage> CreateAsync(CreateOrderDto order, CancellationToken cancellationToken = default)
    {
        try
        {
            var dupCheck = await dbContext.Orders
                                .FirstOrDefaultAsync(o => o.ExternalOrderNumber == order.ExternalOrderNumber, cancellationToken);

            if (dupCheck != null)
            {
                logger.LogWarning("{Announcement} => Duplicated Order number {ORDERNUMBER}",LoggerConstants.WARNING, order.ExternalOrderNumber);
                return new ResponseMessage
                {
                    Success = false,
                    Message = "Duplicated Order number"
                };
            }

            var newOrder = new Order
            {
                ExternalOrderNumber = order.ExternalOrderNumber,
                PlacedAt = order.PlacedAt,
                CreatedAt = DateTimeOffset.UtcNow,
            };

            foreach (var item in order.Items)
            {
                var product = await dbContext.Products
                                    .FirstOrDefaultAsync(product => product.Sku == item.Sku, cancellationToken);

                if (product == null)
                {
                    logger.LogError("{Announcement} => The product {PRODUCT} you are trying to order doesn't exist",LoggerConstants.ERROR, item.Sku);
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "The product you are trying to order doesn't exist"
                    };
                }

                if (product.Qty < item.Qyt)
                {
                    logger.LogError("{Announcement} => Not enough stock on hand for product {PRODUCT}",LoggerConstants.ERROR, item.Sku);
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = $"Not enough stock on hand for product {item.Sku}"
                    };
                }


                newOrder.OrderItems.Add(new OrderItem
                {
                    ProductId = product.Id,
                    Qty = item.Qyt,
                    UnitPrice = item.UnitPrice,
                });
                product.Qty -= item.Qyt;
                product.UpdatedAt = DateTimeOffset.UtcNow;
                product.InventoryAdjustments.Add(new InventoryAdjustment
                {
                    QtyChange = -item.Qyt,
                    Action = StockAdjustments.STOCKDECREASE,
                    CreatedAt = DateTimeOffset.UtcNow
                });
                dbContext.Products.Update(product);
            }

            dbContext.Orders.Add(newOrder);
            await dbContext.SaveChangesAsync(cancellationToken);

            logger.LogError("{Announcement} => Successfully created order {ORDERNUMBER}", LoggerConstants.SUCCESSFUL,order.ExternalOrderNumber);
            return new ResponseMessage
            {
                Success = true,
                Message = $"Successfully created order {order.ExternalOrderNumber}",
                Payload = newOrder
            };
        }
        catch (Exception ex)
        {
            logger.LogError(ex,"{Announcement} => Something went wrong, please try again.", LoggerConstants.FAILED);
            return new ResponseMessage
            {
                Success = false,
                Message = "Something went wrong, please try again."
            };
        }
    }


}
