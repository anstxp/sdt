namespace lab6.Factories.Methologies;

public interface IMethodologyFactory
{
    IMethodology CreateMethodology(Guid projectId);
}

