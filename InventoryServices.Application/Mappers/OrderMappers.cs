using InventoryServices.Application.Dtos.OrderDtos;
using InventoryServices.Domain.Entities;

namespace InventoryServices.Application.Mappers;

public static class OrderMappers
{
    public static Order ToEntity(this CreateOrderDto createOrder)
    {
        return new Order
        {
            ExternalOrderNumber = createOrder.ExternalOrderNumber,
            PlacedAt = createOrder.PlacedAt,
            CreatedAt = DateTimeOffset.UtcNow
        };
    }

}
