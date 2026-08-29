using InventoryServices.Application.Dtos.OrderDtos;
using InventoryServices.Domain.GenericResponse;

namespace InventoryServices.Application.Interfaces.IServices;

public interface IOrderService
{
    Task<bool> AvailableStockCheckAsync(string sku, int orderQy);
    Task<ResponseMessage> CreateAsync(CreateOrderDto orderDto,CancellationToken cancellationToken);
}
