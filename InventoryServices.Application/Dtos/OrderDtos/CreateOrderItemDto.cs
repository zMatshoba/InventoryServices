namespace InventoryServices.Application.Dtos.OrderDtos;

public class CreateOrderItemDto
{
    public string Sku { get; set; } = string.Empty;
    public int Qyt { get; set; }
    public decimal UnitPrice { get; set; }  
}
