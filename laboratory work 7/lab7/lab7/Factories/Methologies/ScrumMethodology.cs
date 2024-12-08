namespace lab7.Factories.Methologies;

public class ScrumMethodology : IMethodology
{
    private readonly Guid _projectId;
    public ScrumMethodology(Guid projectId)
    {
        _projectId = projectId;
    }
    public void Start()
    {
        Console.WriteLine($"Scrum methodology started for project {_projectId}");
    }
    public void Stop()
    {
        Console.WriteLine($"Scrum methodology stopped for project {_projectId}");
    }
    public string GetMethodologyName() => "Scrum";
}

