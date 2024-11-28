using lab6.Factories.Methologies;

namespace lab6.Factories;

public class KanbanFactory : IMethodologyFactory
{
    public IMethodology CreateMethodology(Guid projectId)
    {
        return new KanbanMethodology(projectId);
    }
}

