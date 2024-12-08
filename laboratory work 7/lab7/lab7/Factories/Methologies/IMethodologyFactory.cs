namespace lab7.Factories.Methologies;

public interface IMethodologyFactory
{
    IMethodology CreateMethodology(Guid projectId);
}

