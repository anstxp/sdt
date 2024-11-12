namespace lab2.Repository.Interfaces;
using lab2.Models.Domain;

public interface ITaskCategoryRepository
{
    void Add(TaskCategory taskCategory);
    TaskCategory GetById(int categoryId);
    IEnumerable<TaskCategory> GetAll();
    void Update(TaskCategory taskCategory);
    void Delete(int categoryId);
}