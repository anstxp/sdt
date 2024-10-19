using lab2.Models.Domain;
namespace lab2.Repository.Interfaces;

public interface ISprintRepository
{
    void Add(Sprint sprint);
    Sprint GetById(int sprintId);
    IEnumerable<Sprint> GetAll();
    void Update(Sprint sprint);
    void Delete(int sprintId);
}