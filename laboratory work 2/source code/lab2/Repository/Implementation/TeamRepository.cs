using lab2.Models.Domain;
using lab2.Repository.Interfaces;

namespace lab2.Repository.Implementation;

public class TeamRepository : ITeamRepository
{
    public void Add(Team team)
    {
        // Логіка додавання команди
    }

    public Team GetById(int teamId)
    {
        // Логіка отримання команди за ідентифікатором
        return null;
    }

    public IEnumerable<Team> GetAll()
    {
        // Логіка отримання всіх команд
        return new List<Team>();
    }

    public void Update(Team team)
    {
        // Логіка оновлення команди
    }

    public void Delete(int teamId)
    {
        // Логіка видалення команди
    }
}
