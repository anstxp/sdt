using lab7.Models;

namespace lab7.Repositories.Interfaces;

public interface IMethodologyRepository
{
    Task<string> GetMethodologyByIdAsync(Guid methodologyId);
}

