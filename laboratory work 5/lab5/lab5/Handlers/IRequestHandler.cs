namespace lab5.Handlers;

public interface IRequestHandler
{
    Task HandleAsync(Request request);
    IRequestHandler? Next { get; set; }
}


