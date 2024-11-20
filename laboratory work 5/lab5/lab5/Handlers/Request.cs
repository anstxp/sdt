namespace lab5.Handlers;

public class Request
{
    public string UserId { get; set; }
    public string Action { get; set; }
    public string ResourceType { get; set; }
    public string ResourceName { get; set; }
    public DateTime? StartDate { get; set; }
    public Guid? ResourceId { get; set; }
}

