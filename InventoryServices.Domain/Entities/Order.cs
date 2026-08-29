using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryServices.Domain.Entities;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string ExternalOrderNumber { get; set; } = string.Empty;

    public DateTimeOffset PlacedAt { get; set; }     

    public DateTimeOffset CreatedAt { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = [];
}
