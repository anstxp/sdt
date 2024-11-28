using System.Security.Claims;
using lab6.Factories;
using lab6.Models;
using lab6.Factories.Methologies;
using lab6.Handlers;
using lab6.Handlers.ProjectHandler;
using lab6.Models.Domain;
using lab6.Models.Domain.IdentityEntities;
using lab6.Models.DTO;
using lab6.Repositories;
using lab6.Repositories.Interfaces;
using lab6.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace lab6.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IRequestHandler _handlerChain;
    private readonly MethodologyProvider _methodologyProvider;
    private readonly IMethodologyRepository _methodologyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProjectService(
        UserManager<AppUser> userManager, 
        IProjectRepository projectRepository,
        IMethodologyRepository methodologyRepository,
        MethodologyProvider methodologyProvider,
        IUnitOfWork unitOfWork)
    {
        _handlerChain = BuildHandlerChain(userManager, projectRepository);
        _projectRepository = projectRepository;
        _methodologyRepository = methodologyRepository;
        _methodologyProvider = methodologyProvider;
        _unitOfWork = unitOfWork;
    }

    private static IRequestHandler BuildHandlerChain(
        UserManager<AppUser> userManager,
        IProjectRepository projectRepository)
    {
        var accessControlHandler = new AccessControlHandler(userManager);
        var uniqueProjectCheckHandler = new UniqueProjectCheckHandler(projectRepository);
        var projectDataValidationHandler = new ProjectDataValidationHandler();

        accessControlHandler.Next = uniqueProjectCheckHandler;
        uniqueProjectCheckHandler.Next = projectDataValidationHandler;

        return accessControlHandler;
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
        return await ExecuteWithTransactionAsync(async () =>
        {
            var request = BuildRequest(userId, projectDto);

            await _handlerChain.HandleAsync(request);

            var project = await _projectRepository.CreateProjectAsync(projectDto);
            if (project == null)
            {
                throw new InvalidOperationException("Failed to create the project.");
            }

            var methodologyName = await _methodologyRepository.GetMethodologyByIdAsync(projectDto.MethodologyId);
            var factory = _methodologyProvider.GetFactory(methodologyName);
            var methodology = factory.CreateMethodology(project.ProjectId);

            methodology.Start();

            return project;
        });
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
    
    private static Request BuildRequest(string userId, CreateProjectDTO projectDto)
    {
        return new Request
        {
            UserId = userId,
            Action = "Create",
            ResourceType = "Project",
            ResourceName = projectDto.ProjectName,
            StartDate = projectDto.StartDate
        };
    }
    private async Task<T> ExecuteWithTransactionAsync<T>(Func<Task<T>> operation)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var result = await operation();
            await _unitOfWork.CommitAsync();
            return result;
        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }
}
