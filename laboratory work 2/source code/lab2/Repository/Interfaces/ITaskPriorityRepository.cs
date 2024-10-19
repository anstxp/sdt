using lab2.Models.Domain;

namespace lab2.Repository.Interfaces;

public interface ITaskPriorityRepository
{
    void Add(TaskPriority taskPriority);
    TaskPriority GetById(int priorityId);
    IEnumerable<TaskPriority> GetAll();
    void Update(TaskPriority taskPriority);
    void Delete(int priorityId);
}