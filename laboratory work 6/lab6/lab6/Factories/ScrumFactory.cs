using lab6.Factories.Methologies;

namespace lab6.Factories;

public class ScrumFactory : IMethodologyFactory
{
    public IMethodology CreateMethodology(Guid projectId)
    {
        return new ScrumMethodology(projectId);
    }
}
