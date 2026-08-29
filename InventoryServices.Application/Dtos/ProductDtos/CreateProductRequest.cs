namespace InventoryServices.Application.Dtos.ProductDtos;

public class CreateProductRequest
{
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int InitialQty { get; set; }
}
