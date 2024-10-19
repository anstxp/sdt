using lab2.Repository.Interfaces;

namespace lab2.Repository.Implementation;

public class TaskRepository : ITaskRepository
{
    public void Add(Task task)
    {
        // Логіка додавання завдання
    }

    public Task GetById(int taskId)
    {
        // Логіка отримання завдання за ідентифікатором
        return null;
    }

    public IEnumerable<Task> GetAll()
    {
        // Логіка отримання всіх завдань
        return new List<Task>();
    }

    public void Update(Task task)
    {
        // Логіка оновлення завдання
    }

    public void Delete(int taskId)
    {
        // Логіка видалення завдання
    }
}
