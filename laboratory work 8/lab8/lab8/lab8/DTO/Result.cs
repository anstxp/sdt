namespace WebApplication1.DTO;

public class Result
{
    public bool IsSuccess { get;  set; }
    public string Errors { get; set; }

    public static Result Success() => new Result { IsSuccess = true };
    public static Result Failure(string error) => new Result { IsSuccess = false, Errors = error };
}