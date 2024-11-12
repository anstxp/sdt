using lab2.Models.Domain;
using lab2.Repository.Interfaces;

namespace lab2.Repository.Implementation;

public class ProjectRepository : IProjectRepository
{
    public void Add(Project project)
    {
        // Логіка додавання проекту
    }

    public Project GetById(int projectId)
    {
        // Логіка отримання проекту за ідентифікатором
        return null;
    }

    public IEnumerable<Project> GetAll()
    {
        // Логіка отримання всіх проектів
        return new List<Project>();
    }

    public void Update(Project project)
    {
        // Логіка оновлення проекту
    }

    public void Delete(int projectId)
    {
        // Логіка видалення проекту
    }
}
