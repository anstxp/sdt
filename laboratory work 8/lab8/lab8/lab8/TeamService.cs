using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1;

public class TeamService: ITeamService
{
        private readonly ITeamRepository _teamRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;

    public TeamService(ITeamRepository teamRepository, IUserRepository userRepository,
        ITaskRepository taskRepository, IProjectRepository projectRepository)
    {
        _teamRepository = teamRepository;
        _userRepository = userRepository;
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
    }

    public async Task<ResultT<TeamResponse>> CreateTeamAsync(CreateTeamRequest request)
    {
        var roleFactory = new RoleFlyweightFactory();
        roleFactory.PreloadRoles();

        var project = await ValidateAndGetProjectAsync(request.ProjectId);
        var teamLead = await ValidateAndGetTeamLeadAsync(request.TeamLeadId);
        var users = await ValidateAndGetUsersAsync(request.MemberIds);
        ValidateRequest(request, users);

        var team = CreateTeam(request, teamLead, users, roleFactory);

        await _teamRepository.AddAsync(team);

        var response = MapToResponse(team);
        return ResultT<TeamResponse>.Success(response);
    }

    private async Task<BaseProject> ValidateAndGetProjectAsync(Guid projectId)
    {
        var project = await _projectRepository.GetByIdAsync(projectId);
        if (project == null)
            throw new ArgumentException("Project not found.");
        return project;
    }

    private async Task<AppUser> ValidateAndGetTeamLeadAsync(Guid teamLeadId)
    {
        var teamLead = await _userRepository.GetUserByIdlAsync(teamLeadId);
        if (teamLead == null)
            throw new ArgumentException("Team lead not found.");
        return teamLead;
    }

    private async Task<List<AppUser>> ValidateAndGetUsersAsync(ICollection<Guid> memberIds)
    {
        var users = await _userRepository.GetByIdsAsync(memberIds);
        if (users.Count != memberIds.Count)
            throw new ArgumentException("Some users were not found.");
        return users;
    }

    private void ValidateRequest(CreateTeamRequest request, List<AppUser> users)
    {
        if (request.MemberIds.Distinct().Count() != request.MemberIds.Count)
            throw new ArgumentException("Duplicate members in the team.");
    }

    private Team CreateTeam(CreateTeamRequest request, AppUser teamLead, List<AppUser> users,
        RoleFlyweightFactory roleFactory)
    {
        var teamId = Guid.NewGuid();

        var teamMembers = users.Select(user => CreateTeamMember(user, request, teamId, roleFactory)).ToList();

        return new Team
        {
            TeamId = teamId,
            ProjectId = request.ProjectId,
            TeamName = request.TeamName,
            TeamLeadId = request.TeamLeadId,
            TeamLead = teamLead,
            TeamMembers = teamMembers
        };
    }

    private TeamMember CreateTeamMember(AppUser user, CreateTeamRequest request, Guid teamId,
        RoleFlyweightFactory roleFactory)
    {
        var userRoleRequest = request.MemberRoles?.FirstOrDefault(r => r.UserId == user.Id);
        var role = userRoleRequest != null
            ? roleFactory.GetRole(userRoleRequest.RoleName, "Custom role", userRoleRequest.AccessLevel)
            : roleFactory.GetDefaultRole();

        return new TeamMember
        {
            TeamMemberId = Guid.NewGuid(),
            TeamId = teamId,
            UserId = user.Id,
            Role = role
        };
    }

    private TeamResponse MapToResponse(Team team)
    {
        return new TeamResponse
        {
            TeamId = team.TeamId,
            ProjectId = team.ProjectId,
            TeamName = team.TeamName,
            TeamLeadId = team.TeamLeadId,
            TeamLeadFirstName = team.TeamLead.FirstName,
            TeamLeadLastName = team.TeamLead.LastName,
            TeamLeadEmail = team.TeamLead.Email,
            Members = team.TeamMembers.Select(MapToTeamMemberResponse).ToList()
        };
    }

    private TeamMemberResponse MapToTeamMemberResponse(TeamMember teamMember)
    {
        return new TeamMemberResponse
        {
            UserId = teamMember.UserId,
            FirstName = teamMember.User.FirstName,
            LastName = teamMember.User.LastName,
            Username = teamMember.User.UserName,
            Email = teamMember.User.Email,
            RoleName = teamMember.Role?.Name,
            AccessLevel = teamMember.Role?.AccessLevel.ToString(),
            ImageUrl = teamMember.User.ProfilePictureUrl
        };
    }
}