using lab2.Models.Domain;

namespace lab2.Repository.Interfaces;

public interface IUserRoleRepository
{
    void Add(UserRole userRole);
    UserRole GetById(int roleId);
    IEnumerable<UserRole> GetAll();
    void Update(UserRole userRole);
    void Delete(int roleId);
}