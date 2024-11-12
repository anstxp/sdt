using lab2.Models.Domain;
using lab2.Repository.Interfaces;

namespace lab2.Repository.Implementation;

public class UserRepository : IUserRepository
{
    public void Add(User user)
    {
            // Логіка додавання користувача
    }
    
    public User GetById(int userId) 
    {
        // Логіка отримання користувача за ідентифікатором
        return null;
    }

    public IEnumerable<User> GetAll()
    {
        // Логіка отримання всіх користувачів
        return new List<User>();
    }

    public void Update(User user)
    {
        // Логіка оновлення користувача
    }

    public void Delete(int userId)
    {
        // Логіка видалення користувача
    }
}
