namespace InventoryServices.Application.Dtos.ProductDtos;

public class ViewProductDto
{
    public int Id { get; set; } 
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Qty { get; set; }    

}
