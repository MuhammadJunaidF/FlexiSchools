namespace FlexiSchools.Application.Common.Wrappers;

public class Response<T>
{
    private List<string>? _errors;
    private T? _data;
    private bool? _success;

    public Response()
    {
    }

    public Response(T? data, string? message = null)
    {
        Success = true;
        Message = message;
        Data = data;
    }

    public Response(string message)
    {
        Success = false;
        Message = message;
    }

    public bool? Success { get => _success; set => _success = value; }
    public string? Message { get; set; }
    public List<string>? Errors { get => _errors; set => _errors = value; }
    public T? Data { get => _data; set => _data = value; }
}

