using System.Security.Claims;
using lab5.Handlers;
using lab5.Handlers.ProjectHandler;
using lab5.Models.Domain;
using lab5.Models.Domain.IdentityEntities;
using lab5.Models.DTO;
using lab5.Repositories.Interfaces;
using lab5.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace lab5.Services.Implementations;

public class ProjectService: IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IRequestHandler _handlerChain;

    public ProjectService(UserManager<AppUser> userManager, 
        IProjectRepository projectRepository)
    {
        var accessControlHandler = new AccessControlHandler(userManager);
        var uniqueProjectCheckHandler = new UniqueProjectCheckHandler(projectRepository);
        var projectDataValidationHandler = new ProjectDataValidationHandler();

        accessControlHandler.Next = uniqueProjectCheckHandler;
        uniqueProjectCheckHandler.Next = projectDataValidationHandler;

        _handlerChain = accessControlHandler;
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        return await _projectRepository.GetAllAsync();
    }

    public async Task<Project?> GetProjectByIdAsync(Guid id)
    {
        return await _projectRepository.GetByIdAsync(id);
    }

    public async Task<Project?> CreateProjectAsync(string userId, CreateProjectDTO projectDto)
    {
        var request = new Request
        {
            UserId = userId,
            Action = "Create",
            ResourceType = "Project",
            ResourceName = projectDto.ProjectName,
            StartDate = projectDto.StartDate
        };

        await _handlerChain.HandleAsync(request);

        return await _projectRepository.CreateProjectAsync(projectDto);
    }

    public async Task<Project?> UpdateProjectAsync(Guid id, UpdateProjectDTO project)
    {
        return await _projectRepository.UpdateProjectAsync(id, project);
    }

    public async Task<bool> DeleteProjectAsync(Guid id)
    {
        return await _projectRepository.DeleteProjectAsync(id);
    }
    
    public void Dispose()
    {
        _projectRepository.Dispose();
    }
}
