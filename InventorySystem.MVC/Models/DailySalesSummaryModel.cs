namespace InventorySystem.MVC.Models
{
    public class DailySalesSummaryModel
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public List<DailySalesModel> Days { get; set; } = [];
    }
}
