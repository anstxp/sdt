using lab7.Repositories.Interfaces;

namespace lab7.Factories.Methologies;

public class MethodologyProvider
{
    private readonly Dictionary<string, IMethodologyFactory> _factories;

    public MethodologyProvider()
    {
        _factories = new Dictionary<string, IMethodologyFactory>
        {
            { "Kanban", new KanbanFactory() },
            { "Scrum", new ScrumFactory() }
        };
    }
    public IMethodologyFactory GetFactory(string methodologyName)
    {
        if (!_factories.ContainsKey(methodologyName))
        {
            throw new ArgumentException($"Unsupported methodology: {methodologyName}");
        }

        return _factories[methodologyName];
    }
}



