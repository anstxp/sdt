using lab2.Models.Domain;
using lab2.Repository.Interfaces;

namespace lab2.Repository.Implementation;

public class SprintRepository : ISprintRepository
{
    public void Add(Sprint sprint)
    {
        // Логіка додавання спринту
    }

    public Sprint GetById(int sprintId)
    {
        // Логіка отримання спринту за ідентифікатором
        return null;
    }

    public IEnumerable<Sprint> GetAll()
    {
        // Логіка отримання всіх спринтів
        return new List<Sprint>();
    }

    public void Update(Sprint sprint)
    {
        // Логіка оновлення спринту
    }

    public void Delete(int sprintId)
    {
        // Логіка видалення спринту
    }
}
