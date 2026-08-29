namespace InventoryServices.Domain.Constants;

public static class LoggerConstants
{
    public const string SUCCESSFUL = "Successful";
    public const string FAILED = "Failed";
    public const string WARNING = "Warning";
    public const string ERROR = "error";
}
    

public static class StockAdjustments
{
    public const string INITIAL = "Initial stock";
    public const string STOCKINCREASE = "Stock Increase";
    public const string STOCKDECREASE = "Stock Decrease";
}

public static class OrderStatus
{
    public const string ACCEPTED = "Accepted";
    public const string PARTIALLYACCEPTED = "Partially Accepted";
}