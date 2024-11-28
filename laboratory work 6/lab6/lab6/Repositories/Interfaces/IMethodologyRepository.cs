using lab6.Models;

namespace lab6.Repositories.Interfaces;

public interface IMethodologyRepository
{
    Task<string> GetMethodologyByIdAsync(Guid methodologyId);
}

