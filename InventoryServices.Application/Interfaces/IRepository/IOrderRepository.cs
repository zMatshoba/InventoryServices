using InventoryServices.Application.Dtos.OrderDtos;
using InventoryServices.Domain.Entities;
using InventoryServices.Domain.GenericResponse;

namespace InventoryServices.Application.Interfaces.IRepository;

public interface IOrderRepository
{
    Task<ResponseMessage> CreateAsync(CreateOrderDto order,CancellationToken cancellationToken = default);

}
