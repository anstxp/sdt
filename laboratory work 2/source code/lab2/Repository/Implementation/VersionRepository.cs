using lab2.Repository.Interfaces;

namespace lab2.Repository.Implementation;

public class VersionRepository : IVersionRepository
{
    public void Add(Version version)
    {
        // Логіка додавання версії
    }

    public Version GetById(int versionId)
    {
        // Логіка отримання версії за ідентифікатором
        return null;
    }

    public IEnumerable<Version> GetAll()
    {
        // Логіка отримання всіх версій
        return new List<Version>();
    }

    public void Update(Version version)
    {
        // Логіка оновлення версії
    }

    public void Delete(int versionId)
    {
        // Логіка видалення версії
    }
}
