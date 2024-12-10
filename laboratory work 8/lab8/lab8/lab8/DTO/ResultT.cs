namespace WebApplication1.DTO;

public class ResultT<T>: Result
{
    public T Data { get; set; }

    public static ResultT<T?> Success(T data) => new ResultT<T> { IsSuccess = true, Data = data };
    public static ResultT<T?> Failure(string errors) => new ResultT<T> { IsSuccess = false, Errors = errors };
}
