using lab7.Factories.Methologies;

namespace lab7.Factories;

public class ScrumFactory : IMethodologyFactory
{
    public IMethodology CreateMethodology(Guid projectId)
    {
        return new ScrumMethodology(projectId);
    }
}
