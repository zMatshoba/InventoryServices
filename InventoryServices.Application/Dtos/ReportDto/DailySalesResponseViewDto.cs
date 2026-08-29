namespace InventoryServices.Application.Dtos.ReportDto;

public class DailySalesResponseViewDto
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    public List<DailySalesViewDto> Days { get; set; } = [];
}
