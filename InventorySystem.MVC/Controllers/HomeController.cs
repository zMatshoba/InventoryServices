using InventorySystem.MVC.Models;
using InventorySystem.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace InventorySystem.MVC.Controllers
{
    public class HomeController(IReportService reportService) : Controller
    {

        public async Task<IActionResult> Index(DateOnly? startDate,DateOnly? endDate,CancellationToken cancellationToken)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            var selectedStartDate = startDate ?? today.AddDays(-7); 

            var selectedEndDate = endDate ?? today;

            if (selectedStartDate > selectedEndDate)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "The start date cannot be later than the end date.");

                return View(new DailySalesSummaryModel
                {
                    StartDate = selectedStartDate,
                    EndDate = selectedEndDate,
                    Days = []
                });
            }

            var dailySummary = await reportService.GetDailySalesSummaryAsync(selectedStartDate, selectedEndDate, cancellationToken);

            return View(dailySummary);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
