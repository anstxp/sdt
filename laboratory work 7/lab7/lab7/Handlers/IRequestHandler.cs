namespace lab7.Handlers;

public interface IRequestHandler
{
    Task HandleAsync(Request request);
    IRequestHandler? Next { get; set; }
}


