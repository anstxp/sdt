using lab2.Models.Domain;

namespace lab2.Repository.Interfaces;

public interface IUserRepository
{
    void Add(User user);
    User GetById(int userId);
    IEnumerable<User> GetAll();
    void Update(User user);
    void Delete(int userId);
}