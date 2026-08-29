using InventoryServices.Application.Dtos.ProductDtos;
using InventoryServices.Domain.Entities;

namespace InventoryServices.Application.Mappers;

public static class ProductMappers
{
    public static ViewProductDto ToModel(this Product product)
    {
        return new ViewProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Qty = product.Qty,
            Sku = product.Sku,
        };
    }

    public static Product ToEntity(this CreateProductRequest product)
    {
        return new Product
        {
            Name = product.Name,
            Price = product.Price,
            Qty = product.InitialQty,
            Sku = product.Sku,
            CreatedAt = DateTimeOffset.Now,
        };
    }
}
