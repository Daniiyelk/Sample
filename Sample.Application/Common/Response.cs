namespace Sample.Application.Common;

public class Response<T>
{
    public Response()
    {

    }

    public Response(T data, bool success = true, string message = "")
    {
        Success = success;
        Data = data;
        Message = message;
    }

    public Response(string message)
    {
        Success = false;
        Message = message;
    }

    public bool Success { get; set; }

    public T Data { get; set; }

    public string Message { get; set; }
}
