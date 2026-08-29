namespace InventoryServices.Application.Dtos.OrderDtos;

public class CreateOrderDto
{
    public string ExternalOrderNumber { get; set; } = string.Empty;
    public DateTimeOffset PlacedAt { get; set; }
    public List<CreateOrderItemDto> Items { get; set; } = [];
}
