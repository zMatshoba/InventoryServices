namespace InventorySystem.MVC.Models
{
    public class DailySalesModel
    {
        public DateOnly Date { get; set; }

        public List<ProductTotalModel> Products { get; set; } = [];

        public int TotalQtySold { get; set; }

        public decimal TotalSales { get; set; }
    }
}
