namespace lab2.Repository.Interfaces;

public interface ITaskRepository
{
    void Add(Task task);
    Task GetById(int taskId);
    IEnumerable<Task> GetAll();
    void Update(Task task);
    void Delete(int taskId);
}