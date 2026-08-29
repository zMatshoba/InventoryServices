namespace InventoryServices.Domain.GenericResponse;

public class ResponseMessage
{
    public bool Success { get; set; }
    public object? Payload { get; set; }
    public string? Message { get; set; } 
}
