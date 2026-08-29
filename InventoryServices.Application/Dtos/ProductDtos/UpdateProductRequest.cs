namespace InventoryServices.Application.Dtos.ProductDtos;

public class UpdateProductRequest
{
    public string Sku { get; set; } = string.Empty;
    public decimal Price { get; set; }  
}
