namespace InventorySystem.MVC.Models
{
    public class ProductTotalModel
    {
        public string Sku { get; set; } = string.Empty;
        public int QtySold { get; set; }
        public decimal TotalSales { get; set; }
    }
}
