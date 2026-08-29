using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryServices.Domain.Entities;

public class InventoryAdjustment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int QtyChange { get; set; }

    [StringLength(24)]
    public string Action { get; set; } = string.Empty;

    public DateTimeOffset CreatedAt { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product? Product { get; set; }   
}
