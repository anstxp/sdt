using lab7.Factories.Methologies;

namespace lab7.Factories;

public class KanbanFactory : IMethodologyFactory
{
    public IMethodology CreateMethodology(Guid projectId)
    {
        return new KanbanMethodology(projectId);
    }
}

