namespace lab2.Repository.Interfaces;
using lab2.Models.Domain;

public interface IProjectRepository
{
    void Add(Project project);
    Project GetById(int projectId);
    IEnumerable<Project> GetAll();
    void Update(Project project);
    void Delete(int projectId);
}