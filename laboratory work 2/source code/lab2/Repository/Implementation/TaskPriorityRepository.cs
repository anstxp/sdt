using lab2.Models.Domain;
using lab2.Repository.Interfaces;

namespace lab2.Repository.Implementation;

public class TaskPriorityRepository : ITaskPriorityRepository
{
    public void Add(TaskPriority projectPriority)
    {
        // Логіка додавання пріоритету
    }

    public TaskPriority GetById(int priorityId)
    {
        // Логіка отримання пріоритету за ідентифікатором
        return null;
    }

    public IEnumerable<TaskPriority> GetAll()
    {
        // Логіка отримання всіх пріоритетів
        return new List<TaskPriority>();
    }

    public void Update(TaskPriority projectPriority)
    {
        // Логіка оновлення пріоритету
    }

    public void Delete(int priorityId)
    {
        // Логіка видалення пріоритету
    }
}
