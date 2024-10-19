using lab2.Models.Domain;
using lab2.Repository.Interfaces;

namespace lab2.Repository.Implementation;

public class UserRoleRepository : IUserRoleRepository
{
    public void Add(UserRole userRole)
    {
        // Логіка додавання ролі
    }

    public UserRole GetById(int roleId)
    {
        // Логіка отримання ролі за ідентифікатором
        return null;
    }

    public IEnumerable<UserRole> GetAll()
    {
        // Логіка отримання всіх ролей
        return new List<UserRole>();
    }

    public void Update(UserRole userRole)
    {
        // Логіка оновлення ролі
    }

    public void Delete(int roleId)
    {
        // Логіка видалення ролі
    }
}
