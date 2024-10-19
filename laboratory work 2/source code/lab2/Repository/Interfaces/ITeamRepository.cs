using lab2.Models.Domain;

namespace lab2.Repository.Interfaces;

public interface ITeamRepository
{
    void Add(Team team);
    Team GetById(int teamId);
    IEnumerable<Team> GetAll();
    void Update(Team team);
    void Delete(int teamId);
}