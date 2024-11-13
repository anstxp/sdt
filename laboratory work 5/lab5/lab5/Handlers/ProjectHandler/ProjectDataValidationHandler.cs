namespace lab5.Handlers.ProjectHandler;

public class ProjectDataValidationHandler : IRequestHandler
{
    public async Task HandleAsync(Request request)
    {
        if (string.IsNullOrEmpty(request.ResourceName))
        {
            throw new ArgumentException("Project name cannot be empty.");
        }

        if (request.StartDate == null || request.StartDate < DateTime.Now)
        {
            throw new ArgumentException("Start date must be a valid date in the future.");
        }

        if (Next != null)
        {
            await Next.HandleAsync(request);
        }
    }

    public IRequestHandler? Next { get; set; }
}