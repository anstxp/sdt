using lab2.Models.Domain;

namespace lab2.Repository.Interfaces;

public interface ITeamMemberRepository
{
    void Add(TeamMember teamMember);
    TeamMember GetById(int teamMemberId);
    IEnumerable<TeamMember> GetAll();
    void Update(TeamMember teamMember);
    void Delete(int teamMemberId);
}