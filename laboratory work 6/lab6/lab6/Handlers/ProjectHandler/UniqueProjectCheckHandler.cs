using lab6.Repositories.Interfaces;

namespace lab6.Handlers.ProjectHandler;

public class UniqueProjectCheckHandler : IRequestHandler
{
    private readonly IProjectRepository _projectRepository;

    public UniqueProjectCheckHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task HandleAsync(Request request)
    {
        var existingProject = await _projectRepository.GetByNameAsync(request.ResourceName);
        if (existingProject != null)
        {
            throw new InvalidOperationException("A project with this name already exists.");
        }

        if (Next != null)
        {
            await Next.HandleAsync(request);
        }
    }

    public IRequestHandler? Next { get; set; }
}
