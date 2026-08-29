using InventoryServices.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController(IReportService reportService) : ControllerBase
    {

        [HttpGet("daily-sales-summary")]
        public async Task<ActionResult> Get(DateOnly startDate, DateOnly endDate,CancellationToken cancellationToken)
        {
            var report = await reportService.GetDailySalesSummaryAsync(startDate, endDate,cancellationToken);
            return Ok(report);
        }
    }
}
