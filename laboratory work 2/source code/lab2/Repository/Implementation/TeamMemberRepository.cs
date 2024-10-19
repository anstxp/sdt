using lab2.Models.Domain;
using lab2.Repository.Interfaces;

namespace lab2.Repository.Implementation;

public class TeamMemberRepository : ITeamMemberRepository
{
    public void Add(TeamMember teamMember)
    {
        // Логіка додавання члена команди
    }

    public TeamMember GetById(int teamMemberId)
    {
        // Логіка отримання члена команди за ідентифікатором
        return null;
    }

    public IEnumerable<TeamMember> GetAll()
    {
        // Логіка отримання всіх членів команди
        return new List<TeamMember>();
    }

    public void Update(TeamMember teamMember)
    {
        // Логіка оновлення члена команди
    }

    public void Delete(int teamMemberId)
    {
        // Логіка видалення члена команди
    }
}
