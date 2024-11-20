namespace lab6.Factories.Methologies;
public class KanbanMethodology : IMethodology
{
    private readonly Guid _projectId;
    public KanbanMethodology(Guid projectId)
    {
        _projectId = projectId;
    }
    public void Start()
    {
        Console.WriteLine($"Kanban methodology started for project {_projectId}");
    }
    public void Stop()
    {
        Console.WriteLine($"Kanban methodology stopped for project {_projectId}");
    }
    public string GetMethodologyName() => "Kanban";
}



